using Microsoft.AspNetCore.Html;
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;

namespace VendaProdutos.Services
{
    public class ProductFeedService : IProductFeedService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProductFeedService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        //remove tags html do texto
        public static string RemoverTagsHtml(string html)
        {
            return Regex.Replace(html, "<.*?>", "");
        }

        //substitui caracteres do tipo &ccedil por ç
        public static string DecodificarHtml(string texto)
        {
            return System.Net.WebUtility.HtmlDecode(texto);
        }

        //controla se vai exibir ou não xmlns, http://base.google.com/ns/1.0 dentro das tags do topo do channel
        private void AddElement(XmlDocument xmlDocument, XmlElement parentElement, string tagName, string textContent, bool addNamespace = false)
        {
            XmlElement element;

            if (addNamespace)
            {
                element = xmlDocument.CreateElement(tagName, "http://base.google.com/ns/1.0");
                element.SetAttribute("xmlns", "http://base.google.com/ns/1.0");
            }
            else
            {
                element = xmlDocument.CreateElement(tagName);
            }

            element.InnerText = textContent;
            parentElement.AppendChild(element);
        }

        //Converte preço de 9,99 para 9.99 
        public static string TrocarVirgulaPorPonto(string valor)
        {
            // Substitui a vírgula por ponto
            valor = valor.Replace(',', '.');

            return valor;
        }

        public string GenerateProductFeed()
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlElement rootElement = xmlDocument.CreateElement("rss");
            XmlAttribute xmlnsAttribute = xmlDocument.CreateAttribute("xmlns:g");
            xmlnsAttribute.Value = "http://base.google.com/ns/1.0";
            rootElement.SetAttributeNode(xmlnsAttribute);
            rootElement.SetAttribute("version", "2.0");

            XmlElement channelElement = xmlDocument.CreateElement("channel");

            AddElement(xmlDocument, channelElement, "title", "Feed de Produtos da Pradois Cestas", false);
            AddElement(xmlDocument, channelElement, "link", "https://pradois.com.br/", false);
            AddElement(xmlDocument, channelElement, "description", "Cestas de café da manhã personalizadas para todos os gostos e ocasiões: presenteie com sabor e carinho!", false);

            foreach (var produto in _produtoRepository.Produtos)
            {
                XmlElement itemElement = xmlDocument.CreateElement("item");
                
                var descricao = "com" + " " + produto.QuantidadeDeItem + " " + "itens," + " " + produto.DescricaoCurta;
                string nomeProduto = produto.Nome.Replace(" ", "-");
                string precoPromocionalStr = produto.PrecoPromocional.ToString();
                string descricaoDetalhada = RemoverTagsHtml(produto.DescricaoDetalhada);

                AddElement(xmlDocument, itemElement, "g:id", produto.ProdutoId.ToString());
                AddElement(xmlDocument, itemElement, "g:title", produto.Categoria.NomeCurto + " " + produto.Nome);

                AddElement(xmlDocument, itemElement, "g:description", descricao);
                AddElement(xmlDocument, itemElement, "g:link", $"https://pradois.com.br/Produto/{nomeProduto}-{produto.ProdutoId}");
                AddElement(xmlDocument, itemElement, "g:image_link", produto.ImagemUrl);
                AddElement(xmlDocument, itemElement, "g:price", TrocarVirgulaPorPonto(precoPromocionalStr));

                AddElement(xmlDocument, itemElement, "g:availability", "in stock");
                AddElement(xmlDocument, itemElement, "g:brand", "Pradois Cestas");
                AddElement(xmlDocument, itemElement, "g:condition", "new");

                AddElement(xmlDocument, itemElement, "g:mpn", produto.Sku);
                AddElement(xmlDocument, itemElement, "g:google_product_category", produto.GoogleProductCategory);
                AddElement(xmlDocument, itemElement, "g:product_type", produto.GoogleProductType);
                AddElement(xmlDocument, itemElement, "g:occasion", "Presente");
                AddElement(xmlDocument, itemElement, "g:content", DecodificarHtml(descricaoDetalhada));


                // Adicione outras informações do produto

                channelElement.AppendChild(itemElement);
            }

            rootElement.AppendChild(channelElement);
            xmlDocument.AppendChild(rootElement);

            return FormatXml(xmlDocument);
        }

        private void AddElement(XmlDocument xmlDocument, XmlElement parentElement, string tagName, string textContent)
        {
            XmlElement element = xmlDocument.CreateElement(tagName, "http://base.google.com/ns/1.0");
            element.InnerText = textContent;
            parentElement.AppendChild(element);
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