using System;
using System.Globalization;
using System.Text;
using System.Xml;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;

namespace VendaProdutos.Services
{
    public class SitemapService : ISitemapService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public SitemapService(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }
        string RemoverAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            string normalizedString = texto.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public string GenerateSitemap()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement rootElement = xmlDocument.CreateElement("urlset");

            //SiteMap da home
            // Adiciona a URL da home
            XmlElement homeUrlElement = xmlDocument.CreateElement("url");

            XmlElement homeLocElement = xmlDocument.CreateElement("loc");
            homeLocElement.InnerText = "https://pradois.com.br/"; // URL da home
            homeUrlElement.AppendChild(homeLocElement);

            // Adiciona as novas tags para a home
            XmlElement homeLastModElement = xmlDocument.CreateElement("lastmod");
            homeLastModElement.InnerText = DateTime.Now.ToString("yyyy-MM-dd"); // Atualize conforme necessário
            homeUrlElement.AppendChild(homeLastModElement);

            XmlElement homeChangeFreqElement = xmlDocument.CreateElement("changefreq");
            homeChangeFreqElement.InnerText = "weekly"; // Defina a frequência de mudança conforme necessário
            homeUrlElement.AppendChild(homeChangeFreqElement);

            XmlElement homePriorityElement = xmlDocument.CreateElement("priority");
            homePriorityElement.InnerText = "1.0"; // Defina a prioridade conforme necessário (1.0 para a home)
            homeUrlElement.AppendChild(homePriorityElement);

            rootElement.AppendChild(homeUrlElement);


            // todos os produtos
            if (true)
            {

                XmlElement urlElement = xmlDocument.CreateElement("url");

                XmlElement locElement = xmlDocument.CreateElement("loc");
                locElement.InnerText = $"https://pradois.com.br/Produto/Produto/List";
                urlElement.AppendChild(locElement);

                // Adiciona as novas tags
                XmlElement lastModElement = xmlDocument.CreateElement("lastmod");
                lastModElement.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
                urlElement.AppendChild(lastModElement);

                XmlElement changeFreqElement = xmlDocument.CreateElement("changefreq");
                changeFreqElement.InnerText = "weekly"; // Defina a frequência de mudança conforme necessário
                urlElement.AppendChild(changeFreqElement);

                XmlElement priorityElement = xmlDocument.CreateElement("priority");
                priorityElement.InnerText = "0.7"; // Defina a prioridade conforme necessário (de 0.0 a 1.0)
                urlElement.AppendChild(priorityElement);

                rootElement.AppendChild(urlElement);
            }
             

            // Adiciona URLs de produtos
            foreach (var produto in _produtoRepository.Produtos)
            {
                string nomeProduto = produto.Nome.Replace(" ", "-");
                string nomeProdutoMaisId = RemoverAcentos(nomeProduto + "-" + produto.ProdutoId);

                XmlElement urlElement = xmlDocument.CreateElement("url");

                XmlElement locElement = xmlDocument.CreateElement("loc");
                locElement.InnerText = $"https://pradois.com.br/Produto/{nomeProdutoMaisId}";
                urlElement.AppendChild(locElement);

                // Adiciona as novas tags
                XmlElement lastModElement = xmlDocument.CreateElement("lastmod");
                lastModElement.InnerText = produto.UltimaImplementacao;
                urlElement.AppendChild(lastModElement);

                XmlElement changeFreqElement = xmlDocument.CreateElement("changefreq");
                changeFreqElement.InnerText = "weekly"; // Defina a frequência de mudança conforme necessário
                urlElement.AppendChild(changeFreqElement);

                XmlElement priorityElement = xmlDocument.CreateElement("priority");
                priorityElement.InnerText = "0.8"; // Defina a prioridade conforme necessário (de 0.0 a 1.0)
                urlElement.AppendChild(priorityElement);

                rootElement.AppendChild(urlElement);
            }

            // Adiciona URLs de categorias
            foreach (var categoria in _categoriaRepository.Categorias)
            {
                string nomeCategoria = categoria.CategoriaNome.Replace(" ", "-");
                string nomeCategoriaMaisId = RemoverAcentos(nomeCategoria + "-" + categoria.CategoriaId);

                XmlElement urlElement = xmlDocument.CreateElement("url");

                XmlElement locElement = xmlDocument.CreateElement("loc");
                locElement.InnerText = $"https://pradois.com.br/Categoria/{nomeCategoriaMaisId}";
                urlElement.AppendChild(locElement);

                // Adiciona as novas tags
                XmlElement lastModElement = xmlDocument.CreateElement("lastmod");
                lastModElement.InnerText = categoria.UltimaImplementacao;
                urlElement.AppendChild(lastModElement);

                XmlElement changeFreqElement = xmlDocument.CreateElement("changefreq");
                changeFreqElement.InnerText = "monthly"; // Defina a frequência de mudança conforme necessário
                urlElement.AppendChild(changeFreqElement);

                XmlElement priorityElement = xmlDocument.CreateElement("priority");
                priorityElement.InnerText = "0.9"; // Defina a prioridade conforme necessário (de 0.0 a 1.0)
                urlElement.AppendChild(priorityElement);

                rootElement.AppendChild(urlElement);
            }

            xmlDocument.AppendChild(rootElement);

            return FormatXml(xmlDocument);
        }

        private string FormatXml(XmlDocument xmlDocument)
        {
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true
            };

            using (XmlWriter writer = XmlWriter.Create(stringBuilder, settings))
            {
                xmlDocument.Save(writer);
            }

            return stringBuilder.ToString();
        }
    }
}