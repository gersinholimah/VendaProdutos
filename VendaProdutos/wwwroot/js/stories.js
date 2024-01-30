var De = Object.defineProperty
  , Ge = Object.defineProperties;
var ke = Object.getOwnPropertyDescriptors;
var Se = Object.getOwnPropertySymbols;
var Ve = Object.prototype.hasOwnProperty
  , $e = Object.prototype.propertyIsEnumerable;
var Te = (i,e,t)=>e in i ? De(i, e, {
    enumerable: !0,
    configurable: !0,
    writable: !0,
    value: t
}) : i[e] = t
  , ae = (i,e)=>{
    for (var t in e || (e = {}))
        Ve.call(e, t) && Te(i, t, e[t]);
    if (Se)
        for (var t of Se(e))
            $e.call(e, t) && Te(i, t, e[t]);
    return i
}
  , oe = (i,e)=>Ge(i, ke(e));
const Ne = function() {
    const e = document.createElement("link").relList;
    if (e && e.supports && e.supports("modulepreload"))
        return;
    for (const n of document.querySelectorAll('link[rel="modulepreload"]'))
        s(n);
    new MutationObserver(n=>{
        for (const r of n)
            if (r.type === "childList")
                for (const o of r.addedNodes)
                    o.tagName === "LINK" && o.rel === "modulepreload" && s(o)
    }
    ).observe(document, {
        childList: !0,
        subtree: !0
    });
    function t(n) {
        const r = {};
        return n.integrity && (r.integrity = n.integrity),
        n.referrerpolicy && (r.referrerPolicy = n.referrerpolicy),
        n.crossorigin === "use-credentials" ? r.credentials = "include" : n.crossorigin === "anonymous" ? r.credentials = "omit" : r.credentials = "same-origin",
        r
    }
    function s(n) {
        if (n.ep)
            return;
        n.ep = !0;
        const r = t(n);
        fetch(n.href, r)
    }
};
Ne();
function ye(i) {
    return i !== null && typeof i == "object" && "constructor"in i && i.constructor === Object
}
function ge(i, e) {
    i === void 0 && (i = {}),
    e === void 0 && (e = {}),
    Object.keys(e).forEach(t=>{
        typeof i[t] == "undefined" ? i[t] = e[t] : ye(e[t]) && ye(i[t]) && Object.keys(e[t]).length > 0 && ge(i[t], e[t])
    }
    )
}
const Ce = {
    body: {},
    addEventListener() {},
    removeEventListener() {},
    activeElement: {
        blur() {},
        nodeName: ""
    },
    querySelector() {
        return null
    },
    querySelectorAll() {
        return []
    },
    getElementById() {
        return null
    },
    createEvent() {
        return {
            initEvent() {}
        }
    },
    createElement() {
        return {
            children: [],
            childNodes: [],
            style: {},
            setAttribute() {},
            getElementsByTagName() {
                return []
            }
        }
    },
    createElementNS() {
        return {}
    },
    importNode() {
        return null
    },
    location: {
        hash: "",
        host: "",
        hostname: "",
        href: "",
        origin: "",
        pathname: "",
        protocol: "",
        search: ""
    }
};
function K() {
    const i = typeof document != "undefined" ? document : {};
    return ge(i, Ce),
    i
}
const Fe = {
    document: Ce,
    navigator: {
        userAgent: ""
    },
    location: {
        hash: "",
        host: "",
        hostname: "",
        href: "",
        origin: "",
        pathname: "",
        protocol: "",
        search: ""
    },
    history: {
        replaceState() {},
        pushState() {},
        go() {},
        back() {}
    },
    CustomEvent: function() {
        return this
    },
    addEventListener() {},
    removeEventListener() {},
    getComputedStyle() {
        return {
            getPropertyValue() {
                return ""
            }
        }
    },
    Image() {},
    Date() {},
    screen: {},
    setTimeout() {},
    clearTimeout() {},
    matchMedia() {
        return {}
    },
    requestAnimationFrame(i) {
        return typeof setTimeout == "undefined" ? (i(),
        null) : setTimeout(i, 0)
    },
    cancelAnimationFrame(i) {
        typeof setTimeout != "undefined" && clearTimeout(i)
    }
};
function B() {
    const i = typeof window != "undefined" ? window : {};
    return ge(i, Fe),
    i
}
function Be(i) {
    return i === void 0 && (i = ""),
    i.trim().split(" ").filter(e=>!!e.trim())
}
function _e(i) {
    const e = i;
    Object.keys(e).forEach(t=>{
        try {
            e[t] = null
        } catch {}
        try {
            delete e[t]
        } catch {}
    }
    )
}
function he(i, e) {
    return e === void 0 && (e = 0),
    setTimeout(i, e)
}
function ee() {
    return Date.now()
}
function qe(i) {
    const e = B();
    let t;
    return e.getComputedStyle && (t = e.getComputedStyle(i, null)),
    !t && i.currentStyle && (t = i.currentStyle),
    t || (t = i.style),
    t
}
function He(i, e) {
    e === void 0 && (e = "x");
    const t = B();
    let s, n, r;
    const o = qe(i);
    return t.WebKitCSSMatrix ? (n = o.transform || o.webkitTransform,
    n.split(",").length > 6 && (n = n.split(", ").map(l=>l.replace(",", ".")).join(", ")),
    r = new t.WebKitCSSMatrix(n === "none" ? "" : n)) : (r = o.MozTransform || o.OTransform || o.MsTransform || o.msTransform || o.transform || o.getPropertyValue("transform").replace("translate(", "matrix(1, 0, 0, 1,"),
    s = r.toString().split(",")),
    e === "x" && (t.WebKitCSSMatrix ? n = r.m41 : s.length === 16 ? n = parseFloat(s[12]) : n = parseFloat(s[4])),
    e === "y" && (t.WebKitCSSMatrix ? n = r.m42 : s.length === 16 ? n = parseFloat(s[13]) : n = parseFloat(s[5])),
    n || 0
}
function Z(i) {
    return typeof i == "object" && i !== null && i.constructor && Object.prototype.toString.call(i).slice(8, -1) === "Object"
}
function Re(i) {
    return typeof window != "undefined" && typeof window.HTMLElement != "undefined" ? i instanceof HTMLElement : i && (i.nodeType === 1 || i.nodeType === 11)
}
function F() {
    const i = Object(arguments.length <= 0 ? void 0 : arguments[0])
      , e = ["__proto__", "constructor", "prototype"];
    for (let t = 1; t < arguments.length; t += 1) {
        const s = t < 0 || arguments.length <= t ? void 0 : arguments[t];
        if (s != null && !Re(s)) {
            const n = Object.keys(Object(s)).filter(r=>e.indexOf(r) < 0);
            for (let r = 0, o = n.length; r < o; r += 1) {
                const l = n[r]
                  , a = Object.getOwnPropertyDescriptor(s, l);
                a !== void 0 && a.enumerable && (Z(i[l]) && Z(s[l]) ? s[l].__swiper__ ? i[l] = s[l] : F(i[l], s[l]) : !Z(i[l]) && Z(s[l]) ? (i[l] = {},
                s[l].__swiper__ ? i[l] = s[l] : F(i[l], s[l])) : i[l] = s[l])
            }
        }
    }
    return i
}
function J(i, e, t) {
    i.style.setProperty(e, t)
}
function Le(i) {
    let {swiper: e, targetPosition: t, side: s} = i;
    const n = B()
      , r = -e.translate;
    let o = null, l;
    const a = e.params.speed;
    e.wrapperEl.style.scrollSnapType = "none",
    n.cancelAnimationFrame(e.cssModeFrameID);
    const c = t > r ? "next" : "prev"
      , d = (u,p)=>c === "next" && u >= p || c === "prev" && u <= p
      , f = ()=>{
        l = new Date().getTime(),
        o === null && (o = l);
        const u = Math.max(Math.min((l - o) / a, 1), 0)
          , p = .5 - Math.cos(u * Math.PI) / 2;
        let h = r + p * (t - r);
        if (d(h, t) && (h = t),
        e.wrapperEl.scrollTo({
            [s]: h
        }),
        d(h, t)) {
            e.wrapperEl.style.overflow = "hidden",
            e.wrapperEl.style.scrollSnapType = "",
            setTimeout(()=>{
                e.wrapperEl.style.overflow = "",
                e.wrapperEl.scrollTo({
                    [s]: h
                })
            }
            ),
            n.cancelAnimationFrame(e.cssModeFrameID);
            return
        }
        e.cssModeFrameID = n.requestAnimationFrame(f)
    }
    ;
    f()
}
function W(i, e) {
    return e === void 0 && (e = ""),
    [...i.children].filter(t=>t.matches(e))
}
function te(i) {
    try {
        console.warn(i);
        return
    } catch {}
}
function X(i, e) {
    e === void 0 && (e = []);
    const t = document.createElement(i);
    return t.classList.add(...Array.isArray(e) ? e : Be(e)),
    t
}
function We(i, e) {
    const t = [];
    for (; i.previousElementSibling; ) {
        const s = i.previousElementSibling;
        e ? s.matches(e) && t.push(s) : t.push(s),
        i = s
    }
    return t
}
function je(i, e) {
    const t = [];
    for (; i.nextElementSibling; ) {
        const s = i.nextElementSibling;
        e ? s.matches(e) && t.push(s) : t.push(s),
        i = s
    }
    return t
}
function j(i, e) {
    return B().getComputedStyle(i, null).getPropertyValue(e)
}
function be(i) {
    let e = i, t;
    if (e) {
        for (t = 0; (e = e.previousSibling) !== null; )
            e.nodeType === 1 && (t += 1);
        return t
    }
}
function Xe(i, e) {
    const t = [];
    let s = i.parentElement;
    for (; s; )
        e ? s.matches(e) && t.push(s) : t.push(s),
        s = s.parentElement;
    return t
}
function xe(i, e, t) {
    const s = B();
    return t ? i[e === "width" ? "offsetWidth" : "offsetHeight"] + parseFloat(s.getComputedStyle(i, null).getPropertyValue(e === "width" ? "margin-right" : "margin-top")) + parseFloat(s.getComputedStyle(i, null).getPropertyValue(e === "width" ? "margin-left" : "margin-bottom")) : i.offsetWidth
}
let le;
function Ye() {
    const i = B()
      , e = K();
    return {
        smoothScroll: e.documentElement && e.documentElement.style && "scrollBehavior"in e.documentElement.style,
        touch: !!("ontouchstart"in i || i.DocumentTouch && e instanceof i.DocumentTouch)
    }
}
function Ae() {
    return le || (le = Ye()),
    le
}
let de;
function Ke(i) {
    let {userAgent: e} = i === void 0 ? {} : i;
    const t = Ae()
      , s = B()
      , n = s.navigator.platform
      , r = e || s.navigator.userAgent
      , o = {
        ios: !1,
        android: !1
    }
      , l = s.screen.width
      , a = s.screen.height
      , c = r.match(/(Android);?[\s\/]+([\d.]+)?/);
    let d = r.match(/(iPad).*OS\s([\d_]+)/);
    const f = r.match(/(iPod)(.*OS\s([\d_]+))?/)
      , u = !d && r.match(/(iPhone\sOS|iOS)\s([\d_]+)/)
      , p = n === "Win32";
    let h = n === "MacIntel";
    const T = ["1024x1366", "1366x1024", "834x1194", "1194x834", "834x1112", "1112x834", "768x1024", "1024x768", "820x1180", "1180x820", "810x1080", "1080x810"];
    return !d && h && t.touch && T.indexOf(`${l}x${a}`) >= 0 && (d = r.match(/(Version)\/([\d.]+)/),
    d || (d = [0, 1, "13_0_0"]),
    h = !1),
    c && !p && (o.os = "android",
    o.android = !0),
    (d || u || f) && (o.os = "ios",
    o.ios = !0),
    o
}
function Ue(i) {
    return i === void 0 && (i = {}),
    de || (de = Ke(i)),
    de
}
let ce;
function Ze() {
    const i = B();
    let e = !1;
    function t() {
        const s = i.navigator.userAgent.toLowerCase();
        return s.indexOf("safari") >= 0 && s.indexOf("chrome") < 0 && s.indexOf("android") < 0
    }
    if (t()) {
        const s = String(i.navigator.userAgent);
        if (s.includes("Version/")) {
            const [n,r] = s.split("Version/")[1].split(" ")[0].split(".").map(o=>Number(o));
            e = n < 16 || n === 16 && r < 2
        }
    }
    return {
        isSafari: e || t(),
        needPerspectiveFix: e,
        isWebView: /(iPhone|iPod|iPad).*AppleWebKit(?!.*Safari)/i.test(i.navigator.userAgent)
    }
}
function Je() {
    return ce || (ce = Ze()),
    ce
}
function Qe(i) {
    let {swiper: e, on: t, emit: s} = i;
    const n = B();
    let r = null
      , o = null;
    const l = ()=>{
        !e || e.destroyed || !e.initialized || (s("beforeResize"),
        s("resize"))
    }
      , a = ()=>{
        !e || e.destroyed || !e.initialized || (r = new ResizeObserver(f=>{
            o = n.requestAnimationFrame(()=>{
                const {width: u, height: p} = e;
                let h = u
                  , T = p;
                f.forEach(y=>{
                    let {contentBoxSize: g, contentRect: P, target: v} = y;
                    v && v !== e.el || (h = P ? P.width : (g[0] || g).inlineSize,
                    T = P ? P.height : (g[0] || g).blockSize)
                }
                ),
                (h !== u || T !== p) && l()
            }
            )
        }
        ),
        r.observe(e.el))
    }
      , c = ()=>{
        o && n.cancelAnimationFrame(o),
        r && r.unobserve && e.el && (r.unobserve(e.el),
        r = null)
    }
      , d = ()=>{
        !e || e.destroyed || !e.initialized || s("orientationchange")
    }
    ;
    t("init", ()=>{
        if (e.params.resizeObserver && typeof n.ResizeObserver != "undefined") {
            a();
            return
        }
        n.addEventListener("resize", l),
        n.addEventListener("orientationchange", d)
    }
    ),
    t("destroy", ()=>{
        c(),
        n.removeEventListener("resize", l),
        n.removeEventListener("orientationchange", d)
    }
    )
}
function et(i) {
    let {swiper: e, extendParams: t, on: s, emit: n} = i;
    const r = []
      , o = B()
      , l = function(d, f) {
        f === void 0 && (f = {});
        const u = o.MutationObserver || o.WebkitMutationObserver
          , p = new u(h=>{
            if (e.__preventObserver__)
                return;
            if (h.length === 1) {
                n("observerUpdate", h[0]);
                return
            }
            const T = function() {
                n("observerUpdate", h[0])
            };
            o.requestAnimationFrame ? o.requestAnimationFrame(T) : o.setTimeout(T, 0)
        }
        );
        p.observe(d, {
            attributes: typeof f.attributes == "undefined" ? !0 : f.attributes,
            childList: typeof f.childList == "undefined" ? !0 : f.childList,
            characterData: typeof f.characterData == "undefined" ? !0 : f.characterData
        }),
        r.push(p)
    }
      , a = ()=>{
        if (!!e.params.observer) {
            if (e.params.observeParents) {
                const d = Xe(e.hostEl);
                for (let f = 0; f < d.length; f += 1)
                    l(d[f])
            }
            l(e.hostEl, {
                childList: e.params.observeSlideChildren
            }),
            l(e.wrapperEl, {
                attributes: !1
            })
        }
    }
      , c = ()=>{
        r.forEach(d=>{
            d.disconnect()
        }
        ),
        r.splice(0, r.length)
    }
    ;
    t({
        observer: !1,
        observeParents: !1,
        observeSlideChildren: !1
    }),
    s("init", a),
    s("destroy", c)
}
var tt = {
    on(i, e, t) {
        const s = this;
        if (!s.eventsListeners || s.destroyed || typeof e != "function")
            return s;
        const n = t ? "unshift" : "push";
        return i.split(" ").forEach(r=>{
            s.eventsListeners[r] || (s.eventsListeners[r] = []),
            s.eventsListeners[r][n](e)
        }
        ),
        s
    },
    once(i, e, t) {
        const s = this;
        if (!s.eventsListeners || s.destroyed || typeof e != "function")
            return s;
        function n() {
            s.off(i, n),
            n.__emitterProxy && delete n.__emitterProxy;
            for (var r = arguments.length, o = new Array(r), l = 0; l < r; l++)
                o[l] = arguments[l];
            e.apply(s, o)
        }
        return n.__emitterProxy = e,
        s.on(i, n, t)
    },
    onAny(i, e) {
        const t = this;
        if (!t.eventsListeners || t.destroyed || typeof i != "function")
            return t;
        const s = e ? "unshift" : "push";
        return t.eventsAnyListeners.indexOf(i) < 0 && t.eventsAnyListeners[s](i),
        t
    },
    offAny(i) {
        const e = this;
        if (!e.eventsListeners || e.destroyed || !e.eventsAnyListeners)
            return e;
        const t = e.eventsAnyListeners.indexOf(i);
        return t >= 0 && e.eventsAnyListeners.splice(t, 1),
        e
    },
    off(i, e) {
        const t = this;
        return !t.eventsListeners || t.destroyed || !t.eventsListeners || i.split(" ").forEach(s=>{
            typeof e == "undefined" ? t.eventsListeners[s] = [] : t.eventsListeners[s] && t.eventsListeners[s].forEach((n,r)=>{
                (n === e || n.__emitterProxy && n.__emitterProxy === e) && t.eventsListeners[s].splice(r, 1)
            }
            )
        }
        ),
        t
    },
    emit() {
        const i = this;
        if (!i.eventsListeners || i.destroyed || !i.eventsListeners)
            return i;
        let e, t, s;
        for (var n = arguments.length, r = new Array(n), o = 0; o < n; o++)
            r[o] = arguments[o];
        return typeof r[0] == "string" || Array.isArray(r[0]) ? (e = r[0],
        t = r.slice(1, r.length),
        s = i) : (e = r[0].events,
        t = r[0].data,
        s = r[0].context || i),
        t.unshift(s),
        (Array.isArray(e) ? e : e.split(" ")).forEach(a=>{
            i.eventsAnyListeners && i.eventsAnyListeners.length && i.eventsAnyListeners.forEach(c=>{
                c.apply(s, [a, ...t])
            }
            ),
            i.eventsListeners && i.eventsListeners[a] && i.eventsListeners[a].forEach(c=>{
                c.apply(s, t)
            }
            )
        }
        ),
        i
    }
};
function it() {
    const i = this;
    let e, t;
    const s = i.el;
    typeof i.params.width != "undefined" && i.params.width !== null ? e = i.params.width : e = s.clientWidth,
    typeof i.params.height != "undefined" && i.params.height !== null ? t = i.params.height : t = s.clientHeight,
    !(e === 0 && i.isHorizontal() || t === 0 && i.isVertical()) && (e = e - parseInt(j(s, "padding-left") || 0, 10) - parseInt(j(s, "padding-right") || 0, 10),
    t = t - parseInt(j(s, "padding-top") || 0, 10) - parseInt(j(s, "padding-bottom") || 0, 10),
    Number.isNaN(e) && (e = 0),
    Number.isNaN(t) && (t = 0),
    Object.assign(i, {
        width: e,
        height: t,
        size: i.isHorizontal() ? e : t
    }))
}
function st() {
    const i = this;
    function e(S, b) {
        return parseFloat(S.getPropertyValue(i.getDirectionLabel(b)) || 0)
    }
    const t = i.params
      , {wrapperEl: s, slidesEl: n, size: r, rtlTranslate: o, wrongRTL: l} = i
      , a = i.virtual && t.virtual.enabled
      , c = a ? i.virtual.slides.length : i.slides.length
      , d = W(n, `.${i.params.slideClass}, swiper-slide`)
      , f = a ? i.virtual.slides.length : d.length;
    let u = [];
    const p = []
      , h = [];
    let T = t.slidesOffsetBefore;
    typeof T == "function" && (T = t.slidesOffsetBefore.call(i));
    let y = t.slidesOffsetAfter;
    typeof y == "function" && (y = t.slidesOffsetAfter.call(i));
    const g = i.snapGrid.length
      , P = i.slidesGrid.length;
    let v = t.spaceBetween
      , m = -T
      , M = 0
      , O = 0;
    if (typeof r == "undefined")
        return;
    typeof v == "string" && v.indexOf("%") >= 0 ? v = parseFloat(v.replace("%", "")) / 100 * r : typeof v == "string" && (v = parseFloat(v)),
    i.virtualSize = -v,
    d.forEach(S=>{
        o ? S.style.marginLeft = "" : S.style.marginRight = "",
        S.style.marginBottom = "",
        S.style.marginTop = ""
    }
    ),
    t.centeredSlides && t.cssMode && (J(s, "--swiper-centered-offset-before", ""),
    J(s, "--swiper-centered-offset-after", ""));
    const G = t.grid && t.grid.rows > 1 && i.grid;
    G ? i.grid.initSlides(d) : i.grid && i.grid.unsetSlides();
    let L;
    const D = t.slidesPerView === "auto" && t.breakpoints && Object.keys(t.breakpoints).filter(S=>typeof t.breakpoints[S].slidesPerView != "undefined").length > 0;
    for (let S = 0; S < f; S += 1) {
        L = 0;
        let b;
        if (d[S] && (b = d[S]),
        G && i.grid.updateSlide(S, b, d),
        !(d[S] && j(b, "display") === "none")) {
            if (t.slidesPerView === "auto") {
                D && (d[S].style[i.getDirectionLabel("width")] = "");
                const x = getComputedStyle(b)
                  , E = b.style.transform
                  , z = b.style.webkitTransform;
                if (E && (b.style.transform = "none"),
                z && (b.style.webkitTransform = "none"),
                t.roundLengths)
                    L = i.isHorizontal() ? xe(b, "width", !0) : xe(b, "height", !0);
                else {
                    const $ = e(x, "width")
                      , H = e(x, "padding-left")
                      , ie = e(x, "padding-right")
                      , U = e(x, "margin-left")
                      , se = e(x, "margin-right")
                      , re = x.getPropertyValue("box-sizing");
                    if (re && re === "border-box")
                        L = $ + U + se;
                    else {
                        const {clientWidth: ve, offsetWidth: we} = b;
                        L = $ + H + ie + U + se + (we - ve)
                    }
                }
                E && (b.style.transform = E),
                z && (b.style.webkitTransform = z),
                t.roundLengths && (L = Math.floor(L))
            } else
                L = (r - (t.slidesPerView - 1) * v) / t.slidesPerView,
                t.roundLengths && (L = Math.floor(L)),
                d[S] && (d[S].style[i.getDirectionLabel("width")] = `${L}px`);
            d[S] && (d[S].swiperSlideSize = L),
            h.push(L),
            t.centeredSlides ? (m = m + L / 2 + M / 2 + v,
            M === 0 && S !== 0 && (m = m - r / 2 - v),
            S === 0 && (m = m - r / 2 - v),
            Math.abs(m) < 1 / 1e3 && (m = 0),
            t.roundLengths && (m = Math.floor(m)),
            O % t.slidesPerGroup === 0 && u.push(m),
            p.push(m)) : (t.roundLengths && (m = Math.floor(m)),
            (O - Math.min(i.params.slidesPerGroupSkip, O)) % i.params.slidesPerGroup === 0 && u.push(m),
            p.push(m),
            m = m + L + v),
            i.virtualSize += L + v,
            M = L,
            O += 1
        }
    }
    if (i.virtualSize = Math.max(i.virtualSize, r) + y,
    o && l && (t.effect === "slide" || t.effect === "coverflow") && (s.style.width = `${i.virtualSize + v}px`),
    t.setWrapperSize && (s.style[i.getDirectionLabel("width")] = `${i.virtualSize + v}px`),
    G && i.grid.updateWrapperSize(L, u),
    !t.centeredSlides) {
        const S = [];
        for (let b = 0; b < u.length; b += 1) {
            let x = u[b];
            t.roundLengths && (x = Math.floor(x)),
            u[b] <= i.virtualSize - r && S.push(x)
        }
        u = S,
        Math.floor(i.virtualSize - r) - Math.floor(u[u.length - 1]) > 1 && u.push(i.virtualSize - r)
    }
    if (a && t.loop) {
        const S = h[0] + v;
        if (t.slidesPerGroup > 1) {
            const b = Math.ceil((i.virtual.slidesBefore + i.virtual.slidesAfter) / t.slidesPerGroup)
              , x = S * t.slidesPerGroup;
            for (let E = 0; E < b; E += 1)
                u.push(u[u.length - 1] + x)
        }
        for (let b = 0; b < i.virtual.slidesBefore + i.virtual.slidesAfter; b += 1)
            t.slidesPerGroup === 1 && u.push(u[u.length - 1] + S),
            p.push(p[p.length - 1] + S),
            i.virtualSize += S
    }
    if (u.length === 0 && (u = [0]),
    v !== 0) {
        const S = i.isHorizontal() && o ? "marginLeft" : i.getDirectionLabel("marginRight");
        d.filter((b,x)=>!t.cssMode || t.loop ? !0 : x !== d.length - 1).forEach(b=>{
            b.style[S] = `${v}px`
        }
        )
    }
    if (t.centeredSlides && t.centeredSlidesBounds) {
        let S = 0;
        h.forEach(x=>{
            S += x + (v || 0)
        }
        ),
        S -= v;
        const b = S - r;
        u = u.map(x=>x <= 0 ? -T : x > b ? b + y : x)
    }
    if (t.centerInsufficientSlides) {
        let S = 0;
        if (h.forEach(b=>{
            S += b + (v || 0)
        }
        ),
        S -= v,
        S < r) {
            const b = (r - S) / 2;
            u.forEach((x,E)=>{
                u[E] = x - b
            }
            ),
            p.forEach((x,E)=>{
                p[E] = x + b
            }
            )
        }
    }
    if (Object.assign(i, {
        slides: d,
        snapGrid: u,
        slidesGrid: p,
        slidesSizesGrid: h
    }),
    t.centeredSlides && t.cssMode && !t.centeredSlidesBounds) {
        J(s, "--swiper-centered-offset-before", `${-u[0]}px`),
        J(s, "--swiper-centered-offset-after", `${i.size / 2 - h[h.length - 1] / 2}px`);
        const S = -i.snapGrid[0]
          , b = -i.slidesGrid[0];
        i.snapGrid = i.snapGrid.map(x=>x + S),
        i.slidesGrid = i.slidesGrid.map(x=>x + b)
    }
    if (f !== c && i.emit("slidesLengthChange"),
    u.length !== g && (i.params.watchOverflow && i.checkOverflow(),
    i.emit("snapGridLengthChange")),
    p.length !== P && i.emit("slidesGridLengthChange"),
    t.watchSlidesProgress && i.updateSlidesOffset(),
    !a && !t.cssMode && (t.effect === "slide" || t.effect === "fade")) {
        const S = `${t.containerModifierClass}backface-hidden`
          , b = i.el.classList.contains(S);
        f <= t.maxBackfaceHiddenSlides ? b || i.el.classList.add(S) : b && i.el.classList.remove(S)
    }
}
function rt(i) {
    const e = this
      , t = []
      , s = e.virtual && e.params.virtual.enabled;
    let n = 0, r;
    typeof i == "number" ? e.setTransition(i) : i === !0 && e.setTransition(e.params.speed);
    const o = l=>s ? e.slides[e.getSlideIndexByData(l)] : e.slides[l];
    if (e.params.slidesPerView !== "auto" && e.params.slidesPerView > 1)
        if (e.params.centeredSlides)
            (e.visibleSlides || []).forEach(l=>{
                t.push(l)
            }
            );
        else
            for (r = 0; r < Math.ceil(e.params.slidesPerView); r += 1) {
                const l = e.activeIndex + r;
                if (l > e.slides.length && !s)
                    break;
                t.push(o(l))
            }
    else
        t.push(o(e.activeIndex));
    for (r = 0; r < t.length; r += 1)
        if (typeof t[r] != "undefined") {
            const l = t[r].offsetHeight;
            n = l > n ? l : n
        }
    (n || n === 0) && (e.wrapperEl.style.height = `${n}px`)
}
function nt() {
    const i = this
      , e = i.slides
      , t = i.isElement ? i.isHorizontal() ? i.wrapperEl.offsetLeft : i.wrapperEl.offsetTop : 0;
    for (let s = 0; s < e.length; s += 1)
        e[s].swiperSlideOffset = (i.isHorizontal() ? e[s].offsetLeft : e[s].offsetTop) - t - i.cssOverflowAdjustment()
}
function at(i) {
    i === void 0 && (i = this && this.translate || 0);
    const e = this
      , t = e.params
      , {slides: s, rtlTranslate: n, snapGrid: r} = e;
    if (s.length === 0)
        return;
    typeof s[0].swiperSlideOffset == "undefined" && e.updateSlidesOffset();
    let o = -i;
    n && (o = i),
    s.forEach(a=>{
        a.classList.remove(t.slideVisibleClass, t.slideFullyVisibleClass)
    }
    ),
    e.visibleSlidesIndexes = [],
    e.visibleSlides = [];
    let l = t.spaceBetween;
    typeof l == "string" && l.indexOf("%") >= 0 ? l = parseFloat(l.replace("%", "")) / 100 * e.size : typeof l == "string" && (l = parseFloat(l));
    for (let a = 0; a < s.length; a += 1) {
        const c = s[a];
        let d = c.swiperSlideOffset;
        t.cssMode && t.centeredSlides && (d -= s[0].swiperSlideOffset);
        const f = (o + (t.centeredSlides ? e.minTranslate() : 0) - d) / (c.swiperSlideSize + l)
          , u = (o - r[0] + (t.centeredSlides ? e.minTranslate() : 0) - d) / (c.swiperSlideSize + l)
          , p = -(o - d)
          , h = p + e.slidesSizesGrid[a]
          , T = p >= 0 && p <= e.size - e.slidesSizesGrid[a];
        (p >= 0 && p < e.size - 1 || h > 1 && h <= e.size || p <= 0 && h >= e.size) && (e.visibleSlides.push(c),
        e.visibleSlidesIndexes.push(a),
        s[a].classList.add(t.slideVisibleClass)),
        T && s[a].classList.add(t.slideFullyVisibleClass),
        c.progress = n ? -f : f,
        c.originalProgress = n ? -u : u
    }
}
function ot(i) {
    const e = this;
    if (typeof i == "undefined") {
        const d = e.rtlTranslate ? -1 : 1;
        i = e && e.translate && e.translate * d || 0
    }
    const t = e.params
      , s = e.maxTranslate() - e.minTranslate();
    let {progress: n, isBeginning: r, isEnd: o, progressLoop: l} = e;
    const a = r
      , c = o;
    if (s === 0)
        n = 0,
        r = !0,
        o = !0;
    else {
        n = (i - e.minTranslate()) / s;
        const d = Math.abs(i - e.minTranslate()) < 1
          , f = Math.abs(i - e.maxTranslate()) < 1;
        r = d || n <= 0,
        o = f || n >= 1,
        d && (n = 0),
        f && (n = 1)
    }
    if (t.loop) {
        const d = e.getSlideIndexByData(0)
          , f = e.getSlideIndexByData(e.slides.length - 1)
          , u = e.slidesGrid[d]
          , p = e.slidesGrid[f]
          , h = e.slidesGrid[e.slidesGrid.length - 1]
          , T = Math.abs(i);
        T >= u ? l = (T - u) / h : l = (T + h - p) / h,
        l > 1 && (l -= 1)
    }
    Object.assign(e, {
        progress: n,
        progressLoop: l,
        isBeginning: r,
        isEnd: o
    }),
    (t.watchSlidesProgress || t.centeredSlides && t.autoHeight) && e.updateSlidesProgress(i),
    r && !a && e.emit("reachBeginning toEdge"),
    o && !c && e.emit("reachEnd toEdge"),
    (a && !r || c && !o) && e.emit("fromEdge"),
    e.emit("progress", n)
}
function lt() {
    const i = this
      , {slides: e, params: t, slidesEl: s, activeIndex: n} = i
      , r = i.virtual && t.virtual.enabled
      , o = i.grid && t.grid && t.grid.rows > 1
      , l = f=>W(s, `.${t.slideClass}${f}, swiper-slide${f}`)[0];
    e.forEach(f=>{
        f.classList.remove(t.slideActiveClass, t.slideNextClass, t.slidePrevClass)
    }
    );
    let a, c, d;
    if (r)
        if (t.loop) {
            let f = n - i.virtual.slidesBefore;
            f < 0 && (f = i.virtual.slides.length + f),
            f >= i.virtual.slides.length && (f -= i.virtual.slides.length),
            a = l(`[data-swiper-slide-index="${f}"]`)
        } else
            a = l(`[data-swiper-slide-index="${n}"]`);
    else
        o ? (a = e.filter(f=>f.column === n)[0],
        d = e.filter(f=>f.column === n + 1)[0],
        c = e.filter(f=>f.column === n - 1)[0]) : a = e[n];
    a && (a.classList.add(t.slideActiveClass),
    o ? (d && d.classList.add(t.slideNextClass),
    c && c.classList.add(t.slidePrevClass)) : (d = je(a, `.${t.slideClass}, swiper-slide`)[0],
    t.loop && !d && (d = e[0]),
    d && d.classList.add(t.slideNextClass),
    c = We(a, `.${t.slideClass}, swiper-slide`)[0],
    t.loop && !c === 0 && (c = e[e.length - 1]),
    c && c.classList.add(t.slidePrevClass))),
    i.emitSlidesClasses()
}
const Q = (i,e)=>{
    if (!i || i.destroyed || !i.params)
        return;
    const t = ()=>i.isElement ? "swiper-slide" : `.${i.params.slideClass}`
      , s = e.closest(t());
    if (s) {
        let n = s.querySelector(`.${i.params.lazyPreloaderClass}`);
        !n && i.isElement && (s.shadowRoot ? n = s.shadowRoot.querySelector(`.${i.params.lazyPreloaderClass}`) : requestAnimationFrame(()=>{
            s.shadowRoot && (n = s.shadowRoot.querySelector(`.${i.params.lazyPreloaderClass}`),
            n && n.remove())
        }
        )),
        n && n.remove()
    }
}
  , fe = (i,e)=>{
    if (!i.slides[e])
        return;
    const t = i.slides[e].querySelector('[loading="lazy"]');
    t && t.removeAttribute("loading")
}
  , me = i=>{
    if (!i || i.destroyed || !i.params)
        return;
    let e = i.params.lazyPreloadPrevNext;
    const t = i.slides.length;
    if (!t || !e || e < 0)
        return;
    e = Math.min(e, t);
    const s = i.params.slidesPerView === "auto" ? i.slidesPerViewDynamic() : Math.ceil(i.params.slidesPerView)
      , n = i.activeIndex;
    if (i.params.grid && i.params.grid.rows > 1) {
        const o = n
          , l = [o - e];
        l.push(...Array.from({
            length: e
        }).map((a,c)=>o + s + c)),
        i.slides.forEach((a,c)=>{
            l.includes(a.column) && fe(i, c)
        }
        );
        return
    }
    const r = n + s - 1;
    if (i.params.rewind || i.params.loop)
        for (let o = n - e; o <= r + e; o += 1) {
            const l = (o % t + t) % t;
            (l < n || l > r) && fe(i, l)
        }
    else
        for (let o = Math.max(n - e, 0); o <= Math.min(r + e, t - 1); o += 1)
            o !== n && (o > r || o < n) && fe(i, o)
}
;
function dt(i) {
    const {slidesGrid: e, params: t} = i
      , s = i.rtlTranslate ? i.translate : -i.translate;
    let n;
    for (let r = 0; r < e.length; r += 1)
        typeof e[r + 1] != "undefined" ? s >= e[r] && s < e[r + 1] - (e[r + 1] - e[r]) / 2 ? n = r : s >= e[r] && s < e[r + 1] && (n = r + 1) : s >= e[r] && (n = r);
    return t.normalizeSlideIndex && (n < 0 || typeof n == "undefined") && (n = 0),
    n
}
function ct(i) {
    const e = this
      , t = e.rtlTranslate ? e.translate : -e.translate
      , {snapGrid: s, params: n, activeIndex: r, realIndex: o, snapIndex: l} = e;
    let a = i, c;
    const d = p=>{
        let h = p - e.virtual.slidesBefore;
        return h < 0 && (h = e.virtual.slides.length + h),
        h >= e.virtual.slides.length && (h -= e.virtual.slides.length),
        h
    }
    ;
    if (typeof a == "undefined" && (a = dt(e)),
    s.indexOf(t) >= 0)
        c = s.indexOf(t);
    else {
        const p = Math.min(n.slidesPerGroupSkip, a);
        c = p + Math.floor((a - p) / n.slidesPerGroup)
    }
    if (c >= s.length && (c = s.length - 1),
    a === r && !e.params.loop) {
        c !== l && (e.snapIndex = c,
        e.emit("snapIndexChange"));
        return
    }
    if (a === r && e.params.loop && e.virtual && e.params.virtual.enabled) {
        e.realIndex = d(a);
        return
    }
    const f = e.grid && n.grid && n.grid.rows > 1;
    let u;
    if (e.virtual && n.virtual.enabled && n.loop)
        u = d(a);
    else if (f) {
        const p = e.slides.filter(T=>T.column === a)[0];
        let h = parseInt(p.getAttribute("data-swiper-slide-index"), 10);
        Number.isNaN(h) && (h = Math.max(e.slides.indexOf(p), 0)),
        u = Math.floor(h / n.grid.rows)
    } else if (e.slides[a]) {
        const p = e.slides[a].getAttribute("data-swiper-slide-index");
        p ? u = parseInt(p, 10) : u = a
    } else
        u = a;
    Object.assign(e, {
        previousSnapIndex: l,
        snapIndex: c,
        previousRealIndex: o,
        realIndex: u,
        previousIndex: r,
        activeIndex: a
    }),
    e.initialized && me(e),
    e.emit("activeIndexChange"),
    e.emit("snapIndexChange"),
    (e.initialized || e.params.runCallbacksOnInit) && (o !== u && e.emit("realIndexChange"),
    e.emit("slideChange"))
}
function ft(i, e) {
    const t = this
      , s = t.params;
    let n = i.closest(`.${s.slideClass}, swiper-slide`);
    !n && t.isElement && e && e.length > 1 && e.includes(i) && [...e.slice(e.indexOf(i) + 1, e.length)].forEach(l=>{
        !n && l.matches && l.matches(`.${s.slideClass}, swiper-slide`) && (n = l)
    }
    );
    let r = !1, o;
    if (n) {
        for (let l = 0; l < t.slides.length; l += 1)
            if (t.slides[l] === n) {
                r = !0,
                o = l;
                break
            }
    }
    if (n && r)
        t.clickedSlide = n,
        t.virtual && t.params.virtual.enabled ? t.clickedIndex = parseInt(n.getAttribute("data-swiper-slide-index"), 10) : t.clickedIndex = o;
    else {
        t.clickedSlide = void 0,
        t.clickedIndex = void 0;
        return
    }
    s.slideToClickedSlide && t.clickedIndex !== void 0 && t.clickedIndex !== t.activeIndex && t.slideToClickedSlide()
}
var ut = {
    updateSize: it,
    updateSlides: st,
    updateAutoHeight: rt,
    updateSlidesOffset: nt,
    updateSlidesProgress: at,
    updateProgress: ot,
    updateSlidesClasses: lt,
    updateActiveIndex: ct,
    updateClickedSlide: ft
};
function pt(i) {
    i === void 0 && (i = this.isHorizontal() ? "x" : "y");
    const e = this
      , {params: t, rtlTranslate: s, translate: n, wrapperEl: r} = e;
    if (t.virtualTranslate)
        return s ? -n : n;
    if (t.cssMode)
        return n;
    let o = He(r, i);
    return o += e.cssOverflowAdjustment(),
    s && (o = -o),
    o || 0
}
function ht(i, e) {
    const t = this
      , {rtlTranslate: s, params: n, wrapperEl: r, progress: o} = t;
    let l = 0
      , a = 0;
    const c = 0;
    t.isHorizontal() ? l = s ? -i : i : a = i,
    n.roundLengths && (l = Math.floor(l),
    a = Math.floor(a)),
    t.previousTranslate = t.translate,
    t.translate = t.isHorizontal() ? l : a,
    n.cssMode ? r[t.isHorizontal() ? "scrollLeft" : "scrollTop"] = t.isHorizontal() ? -l : -a : n.virtualTranslate || (t.isHorizontal() ? l -= t.cssOverflowAdjustment() : a -= t.cssOverflowAdjustment(),
    r.style.transform = `translate3d(${l}px, ${a}px, ${c}px)`);
    let d;
    const f = t.maxTranslate() - t.minTranslate();
    f === 0 ? d = 0 : d = (i - t.minTranslate()) / f,
    d !== o && t.updateProgress(i),
    t.emit("setTranslate", t.translate, e)
}
function mt() {
    return -this.snapGrid[0]
}
function gt() {
    return -this.snapGrid[this.snapGrid.length - 1]
}
function vt(i, e, t, s, n) {
    i === void 0 && (i = 0),
    e === void 0 && (e = this.params.speed),
    t === void 0 && (t = !0),
    s === void 0 && (s = !0);
    const r = this
      , {params: o, wrapperEl: l} = r;
    if (r.animating && o.preventInteractionOnTransition)
        return !1;
    const a = r.minTranslate()
      , c = r.maxTranslate();
    let d;
    if (s && i > a ? d = a : s && i < c ? d = c : d = i,
    r.updateProgress(d),
    o.cssMode) {
        const f = r.isHorizontal();
        if (e === 0)
            l[f ? "scrollLeft" : "scrollTop"] = -d;
        else {
            if (!r.support.smoothScroll)
                return Le({
                    swiper: r,
                    targetPosition: -d,
                    side: f ? "left" : "top"
                }),
                !0;
            l.scrollTo({
                [f ? "left" : "top"]: -d,
                behavior: "smooth"
            })
        }
        return !0
    }
    return e === 0 ? (r.setTransition(0),
    r.setTranslate(d),
    t && (r.emit("beforeTransitionStart", e, n),
    r.emit("transitionEnd"))) : (r.setTransition(e),
    r.setTranslate(d),
    t && (r.emit("beforeTransitionStart", e, n),
    r.emit("transitionStart")),
    r.animating || (r.animating = !0,
    r.onTranslateToWrapperTransitionEnd || (r.onTranslateToWrapperTransitionEnd = function(u) {
        !r || r.destroyed || u.target === this && (r.wrapperEl.removeEventListener("transitionend", r.onTranslateToWrapperTransitionEnd),
        r.onTranslateToWrapperTransitionEnd = null,
        delete r.onTranslateToWrapperTransitionEnd,
        t && r.emit("transitionEnd"))
    }
    ),
    r.wrapperEl.addEventListener("transitionend", r.onTranslateToWrapperTransitionEnd))),
    !0
}
var wt = {
    getTranslate: pt,
    setTranslate: ht,
    minTranslate: mt,
    maxTranslate: gt,
    translateTo: vt
};
function St(i, e) {
    const t = this;
    t.params.cssMode || (t.wrapperEl.style.transitionDuration = `${i}ms`,
    t.wrapperEl.style.transitionDelay = i === 0 ? "0ms" : ""),
    t.emit("setTransition", i, e)
}
function Oe(i) {
    let {swiper: e, runCallbacks: t, direction: s, step: n} = i;
    const {activeIndex: r, previousIndex: o} = e;
    let l = s;
    if (l || (r > o ? l = "next" : r < o ? l = "prev" : l = "reset"),
    e.emit(`transition${n}`),
    t && r !== o) {
        if (l === "reset") {
            e.emit(`slideResetTransition${n}`);
            return
        }
        e.emit(`slideChangeTransition${n}`),
        l === "next" ? e.emit(`slideNextTransition${n}`) : e.emit(`slidePrevTransition${n}`)
    }
}
function Tt(i, e) {
    i === void 0 && (i = !0);
    const t = this
      , {params: s} = t;
    s.cssMode || (s.autoHeight && t.updateAutoHeight(),
    Oe({
        swiper: t,
        runCallbacks: i,
        direction: e,
        step: "Start"
    }))
}
function yt(i, e) {
    i === void 0 && (i = !0);
    const t = this
      , {params: s} = t;
    t.animating = !1,
    !s.cssMode && (t.setTransition(0),
    Oe({
        swiper: t,
        runCallbacks: i,
        direction: e,
        step: "End"
    }))
}
var bt = {
    setTransition: St,
    transitionStart: Tt,
    transitionEnd: yt
};
function xt(i, e, t, s, n) {
    i === void 0 && (i = 0),
    e === void 0 && (e = this.params.speed),
    t === void 0 && (t = !0),
    typeof i == "string" && (i = parseInt(i, 10));
    const r = this;
    let o = i;
    o < 0 && (o = 0);
    const {params: l, snapGrid: a, slidesGrid: c, previousIndex: d, activeIndex: f, rtlTranslate: u, wrapperEl: p, enabled: h} = r;
    if (r.animating && l.preventInteractionOnTransition || !h && !s && !n)
        return !1;
    const T = Math.min(r.params.slidesPerGroupSkip, o);
    let y = T + Math.floor((o - T) / r.params.slidesPerGroup);
    y >= a.length && (y = a.length - 1);
    const g = -a[y];
    if (l.normalizeSlideIndex)
        for (let v = 0; v < c.length; v += 1) {
            const m = -Math.floor(g * 100)
              , M = Math.floor(c[v] * 100)
              , O = Math.floor(c[v + 1] * 100);
            typeof c[v + 1] != "undefined" ? m >= M && m < O - (O - M) / 2 ? o = v : m >= M && m < O && (o = v + 1) : m >= M && (o = v)
        }
    if (r.initialized && o !== f && (!r.allowSlideNext && (u ? g > r.translate && g > r.minTranslate() : g < r.translate && g < r.minTranslate()) || !r.allowSlidePrev && g > r.translate && g > r.maxTranslate() && (f || 0) !== o))
        return !1;
    o !== (d || 0) && t && r.emit("beforeSlideChangeStart"),
    r.updateProgress(g);
    let P;
    if (o > f ? P = "next" : o < f ? P = "prev" : P = "reset",
    u && -g === r.translate || !u && g === r.translate)
        return r.updateActiveIndex(o),
        l.autoHeight && r.updateAutoHeight(),
        r.updateSlidesClasses(),
        l.effect !== "slide" && r.setTranslate(g),
        P !== "reset" && (r.transitionStart(t, P),
        r.transitionEnd(t, P)),
        !1;
    if (l.cssMode) {
        const v = r.isHorizontal()
          , m = u ? g : -g;
        if (e === 0) {
            const M = r.virtual && r.params.virtual.enabled;
            M && (r.wrapperEl.style.scrollSnapType = "none",
            r._immediateVirtual = !0),
            M && !r._cssModeVirtualInitialSet && r.params.initialSlide > 0 ? (r._cssModeVirtualInitialSet = !0,
            requestAnimationFrame(()=>{
                p[v ? "scrollLeft" : "scrollTop"] = m
            }
            )) : p[v ? "scrollLeft" : "scrollTop"] = m,
            M && requestAnimationFrame(()=>{
                r.wrapperEl.style.scrollSnapType = "",
                r._immediateVirtual = !1
            }
            )
        } else {
            if (!r.support.smoothScroll)
                return Le({
                    swiper: r,
                    targetPosition: m,
                    side: v ? "left" : "top"
                }),
                !0;
            p.scrollTo({
                [v ? "left" : "top"]: m,
                behavior: "smooth"
            })
        }
        return !0
    }
    return r.setTransition(e),
    r.setTranslate(g),
    r.updateActiveIndex(o),
    r.updateSlidesClasses(),
    r.emit("beforeTransitionStart", e, s),
    r.transitionStart(t, P),
    e === 0 ? r.transitionEnd(t, P) : r.animating || (r.animating = !0,
    r.onSlideToWrapperTransitionEnd || (r.onSlideToWrapperTransitionEnd = function(m) {
        !r || r.destroyed || m.target === this && (r.wrapperEl.removeEventListener("transitionend", r.onSlideToWrapperTransitionEnd),
        r.onSlideToWrapperTransitionEnd = null,
        delete r.onSlideToWrapperTransitionEnd,
        r.transitionEnd(t, P))
    }
    ),
    r.wrapperEl.addEventListener("transitionend", r.onSlideToWrapperTransitionEnd)),
    !0
}
function Et(i, e, t, s) {
    i === void 0 && (i = 0),
    e === void 0 && (e = this.params.speed),
    t === void 0 && (t = !0),
    typeof i == "string" && (i = parseInt(i, 10));
    const n = this
      , r = n.grid && n.params.grid && n.params.grid.rows > 1;
    let o = i;
    if (n.params.loop)
        if (n.virtual && n.params.virtual.enabled)
            o = o + n.virtual.slidesBefore;
        else {
            let l;
            if (r) {
                const u = o * n.params.grid.rows;
                l = n.slides.filter(p=>p.getAttribute("data-swiper-slide-index") * 1 === u)[0].column
            } else
                l = n.getSlideIndexByData(o);
            const a = r ? Math.ceil(n.slides.length / n.params.grid.rows) : n.slides.length
              , {centeredSlides: c} = n.params;
            let d = n.params.slidesPerView;
            d === "auto" ? d = n.slidesPerViewDynamic() : (d = Math.ceil(parseFloat(n.params.slidesPerView, 10)),
            c && d % 2 === 0 && (d = d + 1));
            let f = a - l < d;
            if (c && (f = f || l < Math.ceil(d / 2)),
            f) {
                const u = c ? l < n.activeIndex ? "prev" : "next" : l - n.activeIndex - 1 < n.params.slidesPerView ? "next" : "prev";
                n.loopFix({
                    direction: u,
                    slideTo: !0,
                    activeSlideIndex: u === "next" ? l + 1 : l - a + 1,
                    slideRealIndex: u === "next" ? n.realIndex : void 0
                })
            }
            if (r) {
                const u = o * n.params.grid.rows;
                o = n.slides.filter(p=>p.getAttribute("data-swiper-slide-index") * 1 === u)[0].column
            } else
                o = n.getSlideIndexByData(o)
        }
    return requestAnimationFrame(()=>{
        n.slideTo(o, e, t, s)
    }
    ),
    n
}
function Pt(i, e, t) {
    i === void 0 && (i = this.params.speed),
    e === void 0 && (e = !0);
    const s = this
      , {enabled: n, params: r, animating: o} = s;
    if (!n)
        return s;
    let l = r.slidesPerGroup;
    r.slidesPerView === "auto" && r.slidesPerGroup === 1 && r.slidesPerGroupAuto && (l = Math.max(s.slidesPerViewDynamic("current", !0), 1));
    const a = s.activeIndex < r.slidesPerGroupSkip ? 1 : l
      , c = s.virtual && r.virtual.enabled;
    if (r.loop) {
        if (o && !c && r.loopPreventsSliding)
            return !1;
        if (s.loopFix({
            direction: "next"
        }),
        s._clientLeft = s.wrapperEl.clientLeft,
        s.activeIndex === s.slides.length - 1 && r.cssMode)
            return requestAnimationFrame(()=>{
                s.slideTo(s.activeIndex + a, i, e, t)
            }
            ),
            !0
    }
    return r.rewind && s.isEnd ? s.slideTo(0, i, e, t) : s.slideTo(s.activeIndex + a, i, e, t)
}
function Mt(i, e, t) {
    i === void 0 && (i = this.params.speed),
    e === void 0 && (e = !0);
    const s = this
      , {params: n, snapGrid: r, slidesGrid: o, rtlTranslate: l, enabled: a, animating: c} = s;
    if (!a)
        return s;
    const d = s.virtual && n.virtual.enabled;
    if (n.loop) {
        if (c && !d && n.loopPreventsSliding)
            return !1;
        s.loopFix({
            direction: "prev"
        }),
        s._clientLeft = s.wrapperEl.clientLeft
    }
    const f = l ? s.translate : -s.translate;
    function u(g) {
        return g < 0 ? -Math.floor(Math.abs(g)) : Math.floor(g)
    }
    const p = u(f)
      , h = r.map(g=>u(g));
    let T = r[h.indexOf(p) - 1];
    if (typeof T == "undefined" && n.cssMode) {
        let g;
        r.forEach((P,v)=>{
            p >= P && (g = v)
        }
        ),
        typeof g != "undefined" && (T = r[g > 0 ? g - 1 : g])
    }
    let y = 0;
    if (typeof T != "undefined" && (y = o.indexOf(T),
    y < 0 && (y = s.activeIndex - 1),
    n.slidesPerView === "auto" && n.slidesPerGroup === 1 && n.slidesPerGroupAuto && (y = y - s.slidesPerViewDynamic("previous", !0) + 1,
    y = Math.max(y, 0))),
    n.rewind && s.isBeginning) {
        const g = s.params.virtual && s.params.virtual.enabled && s.virtual ? s.virtual.slides.length - 1 : s.slides.length - 1;
        return s.slideTo(g, i, e, t)
    } else if (n.loop && s.activeIndex === 0 && n.cssMode)
        return requestAnimationFrame(()=>{
            s.slideTo(y, i, e, t)
        }
        ),
        !0;
    return s.slideTo(y, i, e, t)
}
function It(i, e, t) {
    i === void 0 && (i = this.params.speed),
    e === void 0 && (e = !0);
    const s = this;
    return s.slideTo(s.activeIndex, i, e, t)
}
function Ct(i, e, t, s) {
    i === void 0 && (i = this.params.speed),
    e === void 0 && (e = !0),
    s === void 0 && (s = .5);
    const n = this;
    let r = n.activeIndex;
    const o = Math.min(n.params.slidesPerGroupSkip, r)
      , l = o + Math.floor((r - o) / n.params.slidesPerGroup)
      , a = n.rtlTranslate ? n.translate : -n.translate;
    if (a >= n.snapGrid[l]) {
        const c = n.snapGrid[l]
          , d = n.snapGrid[l + 1];
        a - c > (d - c) * s && (r += n.params.slidesPerGroup)
    } else {
        const c = n.snapGrid[l - 1]
          , d = n.snapGrid[l];
        a - c <= (d - c) * s && (r -= n.params.slidesPerGroup)
    }
    return r = Math.max(r, 0),
    r = Math.min(r, n.slidesGrid.length - 1),
    n.slideTo(r, i, e, t)
}
function Lt() {
    const i = this
      , {params: e, slidesEl: t} = i
      , s = e.slidesPerView === "auto" ? i.slidesPerViewDynamic() : e.slidesPerView;
    let n = i.clickedIndex, r;
    const o = i.isElement ? "swiper-slide" : `.${e.slideClass}`;
    if (e.loop) {
        if (i.animating)
            return;
        r = parseInt(i.clickedSlide.getAttribute("data-swiper-slide-index"), 10),
        e.centeredSlides ? n < i.loopedSlides - s / 2 || n > i.slides.length - i.loopedSlides + s / 2 ? (i.loopFix(),
        n = i.getSlideIndex(W(t, `${o}[data-swiper-slide-index="${r}"]`)[0]),
        he(()=>{
            i.slideTo(n)
        }
        )) : i.slideTo(n) : n > i.slides.length - s ? (i.loopFix(),
        n = i.getSlideIndex(W(t, `${o}[data-swiper-slide-index="${r}"]`)[0]),
        he(()=>{
            i.slideTo(n)
        }
        )) : i.slideTo(n)
    } else
        i.slideTo(n)
}
var At = {
    slideTo: xt,
    slideToLoop: Et,
    slideNext: Pt,
    slidePrev: Mt,
    slideReset: It,
    slideToClosest: Ct,
    slideToClickedSlide: Lt
};
function Ot(i) {
    const e = this
      , {params: t, slidesEl: s} = e;
    if (!t.loop || e.virtual && e.params.virtual.enabled)
        return;
    const n = ()=>{
        W(s, `.${t.slideClass}, swiper-slide`).forEach((f,u)=>{
            f.setAttribute("data-swiper-slide-index", u)
        }
        )
    }
      , r = e.grid && t.grid && t.grid.rows > 1
      , o = t.slidesPerGroup * (r ? t.grid.rows : 1)
      , l = e.slides.length % o !== 0
      , a = r && e.slides.length % t.grid.rows !== 0
      , c = d=>{
        for (let f = 0; f < d; f += 1) {
            const u = e.isElement ? X("swiper-slide", [t.slideBlankClass]) : X("div", [t.slideClass, t.slideBlankClass]);
            e.slidesEl.append(u)
        }
    }
    ;
    if (l) {
        if (t.loopAddBlankSlides) {
            const d = o - e.slides.length % o;
            c(d),
            e.recalcSlides(),
            e.updateSlides()
        } else
            te("Swiper Loop Warning: The number of slides is not even to slidesPerGroup, loop mode may not function properly. You need to add more slides (or make duplicates, or empty slides)");
        n()
    } else if (a) {
        if (t.loopAddBlankSlides) {
            const d = t.grid.rows - e.slides.length % t.grid.rows;
            c(d),
            e.recalcSlides(),
            e.updateSlides()
        } else
            te("Swiper Loop Warning: The number of slides is not even to grid.rows, loop mode may not function properly. You need to add more slides (or make duplicates, or empty slides)");
        n()
    } else
        n();
    e.loopFix({
        slideRealIndex: i,
        direction: t.centeredSlides ? void 0 : "next"
    })
}
function zt(i) {
    let {slideRealIndex: e, slideTo: t=!0, direction: s, setTranslate: n, activeSlideIndex: r, byController: o, byMousewheel: l} = i === void 0 ? {} : i;
    const a = this;
    if (!a.params.loop)
        return;
    a.emit("beforeLoopFix");
    const {slides: c, allowSlidePrev: d, allowSlideNext: f, slidesEl: u, params: p} = a
      , {centeredSlides: h} = p;
    if (a.allowSlidePrev = !0,
    a.allowSlideNext = !0,
    a.virtual && p.virtual.enabled) {
        t && (!p.centeredSlides && a.snapIndex === 0 ? a.slideTo(a.virtual.slides.length, 0, !1, !0) : p.centeredSlides && a.snapIndex < p.slidesPerView ? a.slideTo(a.virtual.slides.length + a.snapIndex, 0, !1, !0) : a.snapIndex === a.snapGrid.length - 1 && a.slideTo(a.virtual.slidesBefore, 0, !1, !0)),
        a.allowSlidePrev = d,
        a.allowSlideNext = f,
        a.emit("loopFix");
        return
    }
    let T = p.slidesPerView;
    T === "auto" ? T = a.slidesPerViewDynamic() : (T = Math.ceil(parseFloat(p.slidesPerView, 10)),
    h && T % 2 === 0 && (T = T + 1));
    const y = p.slidesPerGroupAuto ? T : p.slidesPerGroup;
    let g = y;
    g % y !== 0 && (g += y - g % y),
    g += p.loopAdditionalSlides,
    a.loopedSlides = g;
    const P = a.grid && p.grid && p.grid.rows > 1;
    c.length < T + g ? te("Swiper Loop Warning: The number of slides is not enough for loop mode, it will be disabled and not function properly. You need to add more slides (or make duplicates) or lower the values of slidesPerView and slidesPerGroup parameters") : P && p.grid.fill === "row" && te("Swiper Loop Warning: Loop mode is not compatible with grid.fill = `row`");
    const v = []
      , m = [];
    let M = a.activeIndex;
    typeof r == "undefined" ? r = a.getSlideIndex(c.filter(E=>E.classList.contains(p.slideActiveClass))[0]) : M = r;
    const O = s === "next" || !s
      , G = s === "prev" || !s;
    let L = 0
      , D = 0;
    const S = P ? Math.ceil(c.length / p.grid.rows) : c.length
      , x = (P ? c[r].column : r) + (h && typeof n == "undefined" ? -T / 2 + .5 : 0);
    if (x < g) {
        L = Math.max(g - x, y);
        for (let E = 0; E < g - x; E += 1) {
            const z = E - Math.floor(E / S) * S;
            if (P) {
                const $ = S - z - 1;
                for (let H = c.length - 1; H >= 0; H -= 1)
                    c[H].column === $ && v.push(H)
            } else
                v.push(S - z - 1)
        }
    } else if (x + T > S - g) {
        D = Math.max(x - (S - g * 2), y);
        for (let E = 0; E < D; E += 1) {
            const z = E - Math.floor(E / S) * S;
            P ? c.forEach(($,H)=>{
                $.column === z && m.push(H)
            }
            ) : m.push(z)
        }
    }
    if (a.__preventObserver__ = !0,
    requestAnimationFrame(()=>{
        a.__preventObserver__ = !1
    }
    ),
    G && v.forEach(E=>{
        c[E].swiperLoopMoveDOM = !0,
        u.prepend(c[E]),
        c[E].swiperLoopMoveDOM = !1
    }
    ),
    O && m.forEach(E=>{
        c[E].swiperLoopMoveDOM = !0,
        u.append(c[E]),
        c[E].swiperLoopMoveDOM = !1
    }
    ),
    a.recalcSlides(),
    p.slidesPerView === "auto" ? a.updateSlides() : P && (v.length > 0 && G || m.length > 0 && O) && a.slides.forEach((E,z)=>{
        a.grid.updateSlide(z, E, a.slides)
    }
    ),
    p.watchSlidesProgress && a.updateSlidesOffset(),
    t) {
        if (v.length > 0 && G) {
            if (typeof e == "undefined") {
                const E = a.slidesGrid[M]
                  , $ = a.slidesGrid[M + L] - E;
                l ? a.setTranslate(a.translate - $) : (a.slideTo(M + L, 0, !1, !0),
                n && (a.touchEventsData.startTranslate = a.touchEventsData.startTranslate - $,
                a.touchEventsData.currentTranslate = a.touchEventsData.currentTranslate - $))
            } else if (n) {
                const E = P ? v.length / p.grid.rows : v.length;
                a.slideTo(a.activeIndex + E, 0, !1, !0),
                a.touchEventsData.currentTranslate = a.translate
            }
        } else if (m.length > 0 && O)
            if (typeof e == "undefined") {
                const E = a.slidesGrid[M]
                  , $ = a.slidesGrid[M - D] - E;
                l ? a.setTranslate(a.translate - $) : (a.slideTo(M - D, 0, !1, !0),
                n && (a.touchEventsData.startTranslate = a.touchEventsData.startTranslate - $,
                a.touchEventsData.currentTranslate = a.touchEventsData.currentTranslate - $))
            } else {
                const E = P ? m.length / p.grid.rows : m.length;
                a.slideTo(a.activeIndex - E, 0, !1, !0)
            }
    }
    if (a.allowSlidePrev = d,
    a.allowSlideNext = f,
    a.controller && a.controller.control && !o) {
        const E = {
            slideRealIndex: e,
            direction: s,
            setTranslate: n,
            activeSlideIndex: r,
            byController: !0
        };
        Array.isArray(a.controller.control) ? a.controller.control.forEach(z=>{
            !z.destroyed && z.params.loop && z.loopFix(oe(ae({}, E), {
                slideTo: z.params.slidesPerView === p.slidesPerView ? t : !1
            }))
        }
        ) : a.controller.control instanceof a.constructor && a.controller.control.params.loop && a.controller.control.loopFix(oe(ae({}, E), {
            slideTo: a.controller.control.params.slidesPerView === p.slidesPerView ? t : !1
        }))
    }
    a.emit("loopFix")
}
function Dt() {
    const i = this
      , {params: e, slidesEl: t} = i;
    if (!e.loop || i.virtual && i.params.virtual.enabled)
        return;
    i.recalcSlides();
    const s = [];
    i.slides.forEach(n=>{
        const r = typeof n.swiperSlideIndex == "undefined" ? n.getAttribute("data-swiper-slide-index") * 1 : n.swiperSlideIndex;
        s[r] = n
    }
    ),
    i.slides.forEach(n=>{
        n.removeAttribute("data-swiper-slide-index")
    }
    ),
    s.forEach(n=>{
        t.append(n)
    }
    ),
    i.recalcSlides(),
    i.slideTo(i.realIndex, 0)
}
var Gt = {
    loopCreate: Ot,
    loopFix: zt,
    loopDestroy: Dt
};
function kt(i) {
    const e = this;
    if (!e.params.simulateTouch || e.params.watchOverflow && e.isLocked || e.params.cssMode)
        return;
    const t = e.params.touchEventsTarget === "container" ? e.el : e.wrapperEl;
    e.isElement && (e.__preventObserver__ = !0),
    t.style.cursor = "move",
    t.style.cursor = i ? "grabbing" : "grab",
    e.isElement && requestAnimationFrame(()=>{
        e.__preventObserver__ = !1
    }
    )
}
function Vt() {
    const i = this;
    i.params.watchOverflow && i.isLocked || i.params.cssMode || (i.isElement && (i.__preventObserver__ = !0),
    i[i.params.touchEventsTarget === "container" ? "el" : "wrapperEl"].style.cursor = "",
    i.isElement && requestAnimationFrame(()=>{
        i.__preventObserver__ = !1
    }
    ))
}
var $t = {
    setGrabCursor: kt,
    unsetGrabCursor: Vt
};
function Nt(i, e) {
    e === void 0 && (e = this);
    function t(s) {
        if (!s || s === K() || s === B())
            return null;
        s.assignedSlot && (s = s.assignedSlot);
        const n = s.closest(i);
        return !n && !s.getRootNode ? null : n || t(s.getRootNode().host)
    }
    return t(e)
}
function Ee(i, e, t) {
    const s = B()
      , {params: n} = i
      , r = n.edgeSwipeDetection
      , o = n.edgeSwipeThreshold;
    return r && (t <= o || t >= s.innerWidth - o) ? r === "prevent" ? (e.preventDefault(),
    !0) : !1 : !0
}
function Ft(i) {
    const e = this
      , t = K();
    let s = i;
    s.originalEvent && (s = s.originalEvent);
    const n = e.touchEventsData;
    if (s.type === "pointerdown") {
        if (n.pointerId !== null && n.pointerId !== s.pointerId)
            return;
        n.pointerId = s.pointerId
    } else
        s.type === "touchstart" && s.targetTouches.length === 1 && (n.touchId = s.targetTouches[0].identifier);
    if (s.type === "touchstart") {
        Ee(e, s, s.targetTouches[0].pageX);
        return
    }
    const {params: r, touches: o, enabled: l} = e;
    if (!l || !r.simulateTouch && s.pointerType === "mouse" || e.animating && r.preventInteractionOnTransition)
        return;
    !e.animating && r.cssMode && r.loop && e.loopFix();
    let a = s.target;
    if (r.touchEventsTarget === "wrapper" && !e.wrapperEl.contains(a) || "which"in s && s.which === 3 || "button"in s && s.button > 0 || n.isTouched && n.isMoved)
        return;
    const c = !!r.noSwipingClass && r.noSwipingClass !== ""
      , d = s.composedPath ? s.composedPath() : s.path;
    c && s.target && s.target.shadowRoot && d && (a = d[0]);
    const f = r.noSwipingSelector ? r.noSwipingSelector : `.${r.noSwipingClass}`
      , u = !!(s.target && s.target.shadowRoot);
    if (r.noSwiping && (u ? Nt(f, a) : a.closest(f))) {
        e.allowClick = !0;
        return
    }
    if (r.swipeHandler && !a.closest(r.swipeHandler))
        return;
    o.currentX = s.pageX,
    o.currentY = s.pageY;
    const p = o.currentX
      , h = o.currentY;
    if (!Ee(e, s, p))
        return;
    Object.assign(n, {
        isTouched: !0,
        isMoved: !1,
        allowTouchCallbacks: !0,
        isScrolling: void 0,
        startMoving: void 0
    }),
    o.startX = p,
    o.startY = h,
    n.touchStartTime = ee(),
    e.allowClick = !0,
    e.updateSize(),
    e.swipeDirection = void 0,
    r.threshold > 0 && (n.allowThresholdMove = !1);
    let T = !0;
    a.matches(n.focusableElements) && (T = !1,
    a.nodeName === "SELECT" && (n.isTouched = !1)),
    t.activeElement && t.activeElement.matches(n.focusableElements) && t.activeElement !== a && t.activeElement.blur();
    const y = T && e.allowTouchMove && r.touchStartPreventDefault;
    (r.touchStartForcePreventDefault || y) && !a.isContentEditable && s.preventDefault(),
    r.freeMode && r.freeMode.enabled && e.freeMode && e.animating && !r.cssMode && e.freeMode.onTouchStart(),
    e.emit("touchStart", s)
}
function Bt(i) {
    const e = K()
      , t = this
      , s = t.touchEventsData
      , {params: n, touches: r, rtlTranslate: o, enabled: l} = t;
    if (!l || !n.simulateTouch && i.pointerType === "mouse")
        return;
    let a = i;
    if (a.originalEvent && (a = a.originalEvent),
    a.type === "pointermove" && (s.touchId !== null || a.pointerId !== s.pointerId))
        return;
    let c;
    if (a.type === "touchmove") {
        if (c = [...a.changedTouches].filter(O=>O.identifier === s.touchId)[0],
        !c || c.identifier !== s.touchId)
            return
    } else
        c = a;
    if (!s.isTouched) {
        s.startMoving && s.isScrolling && t.emit("touchMoveOpposite", a);
        return
    }
    const d = c.pageX
      , f = c.pageY;
    if (a.preventedByNestedSwiper) {
        r.startX = d,
        r.startY = f;
        return
    }
    if (!t.allowTouchMove) {
        a.target.matches(s.focusableElements) || (t.allowClick = !1),
        s.isTouched && (Object.assign(r, {
            startX: d,
            startY: f,
            currentX: d,
            currentY: f
        }),
        s.touchStartTime = ee());
        return
    }
    if (n.touchReleaseOnEdges && !n.loop) {
        if (t.isVertical()) {
            if (f < r.startY && t.translate <= t.maxTranslate() || f > r.startY && t.translate >= t.minTranslate()) {
                s.isTouched = !1,
                s.isMoved = !1;
                return
            }
        } else if (d < r.startX && t.translate <= t.maxTranslate() || d > r.startX && t.translate >= t.minTranslate())
            return
    }
    if (e.activeElement && a.target === e.activeElement && a.target.matches(s.focusableElements)) {
        s.isMoved = !0,
        t.allowClick = !1;
        return
    }
    s.allowTouchCallbacks && t.emit("touchMove", a),
    r.previousX = r.currentX,
    r.previousY = r.currentY,
    r.currentX = d,
    r.currentY = f;
    const u = r.currentX - r.startX
      , p = r.currentY - r.startY;
    if (t.params.threshold && Math.sqrt(u ** 2 + p ** 2) < t.params.threshold)
        return;
    if (typeof s.isScrolling == "undefined") {
        let O;
        t.isHorizontal() && r.currentY === r.startY || t.isVertical() && r.currentX === r.startX ? s.isScrolling = !1 : u * u + p * p >= 25 && (O = Math.atan2(Math.abs(p), Math.abs(u)) * 180 / Math.PI,
        s.isScrolling = t.isHorizontal() ? O > n.touchAngle : 90 - O > n.touchAngle)
    }
    if (s.isScrolling && t.emit("touchMoveOpposite", a),
    typeof s.startMoving == "undefined" && (r.currentX !== r.startX || r.currentY !== r.startY) && (s.startMoving = !0),
    s.isScrolling) {
        s.isTouched = !1;
        return
    }
    if (!s.startMoving)
        return;
    t.allowClick = !1,
    !n.cssMode && a.cancelable && a.preventDefault(),
    n.touchMoveStopPropagation && !n.nested && a.stopPropagation();
    let h = t.isHorizontal() ? u : p
      , T = t.isHorizontal() ? r.currentX - r.previousX : r.currentY - r.previousY;
    n.oneWayMovement && (h = Math.abs(h) * (o ? 1 : -1),
    T = Math.abs(T) * (o ? 1 : -1)),
    r.diff = h,
    h *= n.touchRatio,
    o && (h = -h,
    T = -T);
    const y = t.touchesDirection;
    t.swipeDirection = h > 0 ? "prev" : "next",
    t.touchesDirection = T > 0 ? "prev" : "next";
    const g = t.params.loop && !n.cssMode
      , P = t.touchesDirection === "next" && t.allowSlideNext || t.touchesDirection === "prev" && t.allowSlidePrev;
    if (!s.isMoved) {
        if (g && P && t.loopFix({
            direction: t.swipeDirection
        }),
        s.startTranslate = t.getTranslate(),
        t.setTransition(0),
        t.animating) {
            const O = new window.CustomEvent("transitionend",{
                bubbles: !0,
                cancelable: !0
            });
            t.wrapperEl.dispatchEvent(O)
        }
        s.allowMomentumBounce = !1,
        n.grabCursor && (t.allowSlideNext === !0 || t.allowSlidePrev === !0) && t.setGrabCursor(!0),
        t.emit("sliderFirstMove", a)
    }
    let v;
    if (new Date().getTime(),
    s.isMoved && s.allowThresholdMove && y !== t.touchesDirection && g && P && Math.abs(h) >= 1) {
        Object.assign(r, {
            startX: d,
            startY: f,
            currentX: d,
            currentY: f,
            startTranslate: s.currentTranslate
        }),
        s.loopSwapReset = !0,
        s.startTranslate = s.currentTranslate;
        return
    }
    t.emit("sliderMove", a),
    s.isMoved = !0,
    s.currentTranslate = h + s.startTranslate;
    let m = !0
      , M = n.resistanceRatio;
    if (n.touchReleaseOnEdges && (M = 0),
    h > 0 ? (g && P && !v && s.allowThresholdMove && s.currentTranslate > (n.centeredSlides ? t.minTranslate() - t.slidesSizesGrid[t.activeIndex + 1] : t.minTranslate()) && t.loopFix({
        direction: "prev",
        setTranslate: !0,
        activeSlideIndex: 0
    }),
    s.currentTranslate > t.minTranslate() && (m = !1,
    n.resistance && (s.currentTranslate = t.minTranslate() - 1 + (-t.minTranslate() + s.startTranslate + h) ** M))) : h < 0 && (g && P && !v && s.allowThresholdMove && s.currentTranslate < (n.centeredSlides ? t.maxTranslate() + t.slidesSizesGrid[t.slidesSizesGrid.length - 1] : t.maxTranslate()) && t.loopFix({
        direction: "next",
        setTranslate: !0,
        activeSlideIndex: t.slides.length - (n.slidesPerView === "auto" ? t.slidesPerViewDynamic() : Math.ceil(parseFloat(n.slidesPerView, 10)))
    }),
    s.currentTranslate < t.maxTranslate() && (m = !1,
    n.resistance && (s.currentTranslate = t.maxTranslate() + 1 - (t.maxTranslate() - s.startTranslate - h) ** M))),
    m && (a.preventedByNestedSwiper = !0),
    !t.allowSlideNext && t.swipeDirection === "next" && s.currentTranslate < s.startTranslate && (s.currentTranslate = s.startTranslate),
    !t.allowSlidePrev && t.swipeDirection === "prev" && s.currentTranslate > s.startTranslate && (s.currentTranslate = s.startTranslate),
    !t.allowSlidePrev && !t.allowSlideNext && (s.currentTranslate = s.startTranslate),
    n.threshold > 0)
        if (Math.abs(h) > n.threshold || s.allowThresholdMove) {
            if (!s.allowThresholdMove) {
                s.allowThresholdMove = !0,
                r.startX = r.currentX,
                r.startY = r.currentY,
                s.currentTranslate = s.startTranslate,
                r.diff = t.isHorizontal() ? r.currentX - r.startX : r.currentY - r.startY;
                return
            }
        } else {
            s.currentTranslate = s.startTranslate;
            return
        }
    !n.followFinger || n.cssMode || ((n.freeMode && n.freeMode.enabled && t.freeMode || n.watchSlidesProgress) && (t.updateActiveIndex(),
    t.updateSlidesClasses()),
    n.freeMode && n.freeMode.enabled && t.freeMode && t.freeMode.onTouchMove(),
    t.updateProgress(s.currentTranslate),
    t.setTranslate(s.currentTranslate))
}
function _t(i) {
    const e = this
      , t = e.touchEventsData;
    let s = i;
    s.originalEvent && (s = s.originalEvent);
    let n;
    if (s.type === "touchend" || s.type === "touchcancel") {
        if (n = [...s.changedTouches].filter(m=>m.identifier === t.touchId)[0],
        !n || n.identifier !== t.touchId)
            return
    } else {
        if (t.touchId !== null || s.pointerId !== t.pointerId)
            return;
        n = s
    }
    if (["pointercancel", "pointerout", "pointerleave", "contextmenu"].includes(s.type) && !(["pointercancel", "contextmenu"].includes(s.type) && (e.browser.isSafari || e.browser.isWebView)))
        return;
    t.pointerId = null,
    t.touchId = null;
    const {params: o, touches: l, rtlTranslate: a, slidesGrid: c, enabled: d} = e;
    if (!d || !o.simulateTouch && s.pointerType === "mouse")
        return;
    if (t.allowTouchCallbacks && e.emit("touchEnd", s),
    t.allowTouchCallbacks = !1,
    !t.isTouched) {
        t.isMoved && o.grabCursor && e.setGrabCursor(!1),
        t.isMoved = !1,
        t.startMoving = !1;
        return
    }
    o.grabCursor && t.isMoved && t.isTouched && (e.allowSlideNext === !0 || e.allowSlidePrev === !0) && e.setGrabCursor(!1);
    const f = ee()
      , u = f - t.touchStartTime;
    if (e.allowClick) {
        const m = s.path || s.composedPath && s.composedPath();
        e.updateClickedSlide(m && m[0] || s.target, m),
        e.emit("tap click", s),
        u < 300 && f - t.lastClickTime < 300 && e.emit("doubleTap doubleClick", s)
    }
    if (t.lastClickTime = ee(),
    he(()=>{
        e.destroyed || (e.allowClick = !0)
    }
    ),
    !t.isTouched || !t.isMoved || !e.swipeDirection || l.diff === 0 && !t.loopSwapReset || t.currentTranslate === t.startTranslate && !t.loopSwapReset) {
        t.isTouched = !1,
        t.isMoved = !1,
        t.startMoving = !1;
        return
    }
    t.isTouched = !1,
    t.isMoved = !1,
    t.startMoving = !1;
    let p;
    if (o.followFinger ? p = a ? e.translate : -e.translate : p = -t.currentTranslate,
    o.cssMode)
        return;
    if (o.freeMode && o.freeMode.enabled) {
        e.freeMode.onTouchEnd({
            currentPos: p
        });
        return
    }
    let h = 0
      , T = e.slidesSizesGrid[0];
    for (let m = 0; m < c.length; m += m < o.slidesPerGroupSkip ? 1 : o.slidesPerGroup) {
        const M = m < o.slidesPerGroupSkip - 1 ? 1 : o.slidesPerGroup;
        typeof c[m + M] != "undefined" ? p >= c[m] && p < c[m + M] && (h = m,
        T = c[m + M] - c[m]) : p >= c[m] && (h = m,
        T = c[c.length - 1] - c[c.length - 2])
    }
    let y = null
      , g = null;
    o.rewind && (e.isBeginning ? g = o.virtual && o.virtual.enabled && e.virtual ? e.virtual.slides.length - 1 : e.slides.length - 1 : e.isEnd && (y = 0));
    const P = (p - c[h]) / T
      , v = h < o.slidesPerGroupSkip - 1 ? 1 : o.slidesPerGroup;
    if (u > o.longSwipesMs) {
        if (!o.longSwipes) {
            e.slideTo(e.activeIndex);
            return
        }
        e.swipeDirection === "next" && (P >= o.longSwipesRatio ? e.slideTo(o.rewind && e.isEnd ? y : h + v) : e.slideTo(h)),
        e.swipeDirection === "prev" && (P > 1 - o.longSwipesRatio ? e.slideTo(h + v) : g !== null && P < 0 && Math.abs(P) > o.longSwipesRatio ? e.slideTo(g) : e.slideTo(h))
    } else {
        if (!o.shortSwipes) {
            e.slideTo(e.activeIndex);
            return
        }
        e.navigation && (s.target === e.navigation.nextEl || s.target === e.navigation.prevEl) ? s.target === e.navigation.nextEl ? e.slideTo(h + v) : e.slideTo(h) : (e.swipeDirection === "next" && e.slideTo(y !== null ? y : h + v),
        e.swipeDirection === "prev" && e.slideTo(g !== null ? g : h))
    }
}
function Pe() {
    const i = this
      , {params: e, el: t} = i;
    if (t && t.offsetWidth === 0)
        return;
    e.breakpoints && i.setBreakpoint();
    const {allowSlideNext: s, allowSlidePrev: n, snapGrid: r} = i
      , o = i.virtual && i.params.virtual.enabled;
    i.allowSlideNext = !0,
    i.allowSlidePrev = !0,
    i.updateSize(),
    i.updateSlides(),
    i.updateSlidesClasses();
    const l = o && e.loop;
    (e.slidesPerView === "auto" || e.slidesPerView > 1) && i.isEnd && !i.isBeginning && !i.params.centeredSlides && !l ? i.slideTo(i.slides.length - 1, 0, !1, !0) : i.params.loop && !o ? i.slideToLoop(i.realIndex, 0, !1, !0) : i.slideTo(i.activeIndex, 0, !1, !0),
    i.autoplay && i.autoplay.running && i.autoplay.paused && (clearTimeout(i.autoplay.resizeTimeout),
    i.autoplay.resizeTimeout = setTimeout(()=>{
        i.autoplay && i.autoplay.running && i.autoplay.paused && i.autoplay.resume()
    }
    , 500)),
    i.allowSlidePrev = n,
    i.allowSlideNext = s,
    i.params.watchOverflow && r !== i.snapGrid && i.checkOverflow()
}
function qt(i) {
    const e = this;
    !e.enabled || e.allowClick || (e.params.preventClicks && i.preventDefault(),
    e.params.preventClicksPropagation && e.animating && (i.stopPropagation(),
    i.stopImmediatePropagation()))
}
function Ht() {
    const i = this
      , {wrapperEl: e, rtlTranslate: t, enabled: s} = i;
    if (!s)
        return;
    i.previousTranslate = i.translate,
    i.isHorizontal() ? i.translate = -e.scrollLeft : i.translate = -e.scrollTop,
    i.translate === 0 && (i.translate = 0),
    i.updateActiveIndex(),
    i.updateSlidesClasses();
    let n;
    const r = i.maxTranslate() - i.minTranslate();
    r === 0 ? n = 0 : n = (i.translate - i.minTranslate()) / r,
    n !== i.progress && i.updateProgress(t ? -i.translate : i.translate),
    i.emit("setTranslate", i.translate, !1)
}
function Rt(i) {
    const e = this;
    Q(e, i.target),
    !(e.params.cssMode || e.params.slidesPerView !== "auto" && !e.params.autoHeight) && e.update()
}
function Wt() {
    const i = this;
    i.documentTouchHandlerProceeded || (i.documentTouchHandlerProceeded = !0,
    i.params.touchReleaseOnEdges && (i.el.style.touchAction = "auto"))
}
const ze = (i,e)=>{
    const t = K()
      , {params: s, el: n, wrapperEl: r, device: o} = i
      , l = !!s.nested
      , a = e === "on" ? "addEventListener" : "removeEventListener"
      , c = e;
    t[a]("touchstart", i.onDocumentTouchStart, {
        passive: !1,
        capture: l
    }),
    n[a]("touchstart", i.onTouchStart, {
        passive: !1
    }),
    n[a]("pointerdown", i.onTouchStart, {
        passive: !1
    }),
    t[a]("touchmove", i.onTouchMove, {
        passive: !1,
        capture: l
    }),
    t[a]("pointermove", i.onTouchMove, {
        passive: !1,
        capture: l
    }),
    t[a]("touchend", i.onTouchEnd, {
        passive: !0
    }),
    t[a]("pointerup", i.onTouchEnd, {
        passive: !0
    }),
    t[a]("pointercancel", i.onTouchEnd, {
        passive: !0
    }),
    t[a]("touchcancel", i.onTouchEnd, {
        passive: !0
    }),
    t[a]("pointerout", i.onTouchEnd, {
        passive: !0
    }),
    t[a]("pointerleave", i.onTouchEnd, {
        passive: !0
    }),
    t[a]("contextmenu", i.onTouchEnd, {
        passive: !0
    }),
    (s.preventClicks || s.preventClicksPropagation) && n[a]("click", i.onClick, !0),
    s.cssMode && r[a]("scroll", i.onScroll),
    s.updateOnWindowResize ? i[c](o.ios || o.android ? "resize orientationchange observerUpdate" : "resize observerUpdate", Pe, !0) : i[c]("observerUpdate", Pe, !0),
    n[a]("load", i.onLoad, {
        capture: !0
    })
}
;
function jt() {
    const i = this
      , {params: e} = i;
    i.onTouchStart = Ft.bind(i),
    i.onTouchMove = Bt.bind(i),
    i.onTouchEnd = _t.bind(i),
    i.onDocumentTouchStart = Wt.bind(i),
    e.cssMode && (i.onScroll = Ht.bind(i)),
    i.onClick = qt.bind(i),
    i.onLoad = Rt.bind(i),
    ze(i, "on")
}
function Xt() {
    ze(this, "off")
}
var Yt = {
    attachEvents: jt,
    detachEvents: Xt
};
const Me = (i,e)=>i.grid && e.grid && e.grid.rows > 1;
function Kt() {
    const i = this
      , {realIndex: e, initialized: t, params: s, el: n} = i
      , r = s.breakpoints;
    if (!r || r && Object.keys(r).length === 0)
        return;
    const o = i.getBreakpoint(r, i.params.breakpointsBase, i.el);
    if (!o || i.currentBreakpoint === o)
        return;
    const a = (o in r ? r[o] : void 0) || i.originalParams
      , c = Me(i, s)
      , d = Me(i, a)
      , f = s.enabled;
    c && !d ? (n.classList.remove(`${s.containerModifierClass}grid`, `${s.containerModifierClass}grid-column`),
    i.emitContainerClasses()) : !c && d && (n.classList.add(`${s.containerModifierClass}grid`),
    (a.grid.fill && a.grid.fill === "column" || !a.grid.fill && s.grid.fill === "column") && n.classList.add(`${s.containerModifierClass}grid-column`),
    i.emitContainerClasses()),
    ["navigation", "pagination", "scrollbar"].forEach(g=>{
        if (typeof a[g] == "undefined")
            return;
        const P = s[g] && s[g].enabled
          , v = a[g] && a[g].enabled;
        P && !v && i[g].disable(),
        !P && v && i[g].enable()
    }
    );
    const u = a.direction && a.direction !== s.direction
      , p = s.loop && (a.slidesPerView !== s.slidesPerView || u)
      , h = s.loop;
    u && t && i.changeDirection(),
    F(i.params, a);
    const T = i.params.enabled
      , y = i.params.loop;
    Object.assign(i, {
        allowTouchMove: i.params.allowTouchMove,
        allowSlideNext: i.params.allowSlideNext,
        allowSlidePrev: i.params.allowSlidePrev
    }),
    f && !T ? i.disable() : !f && T && i.enable(),
    i.currentBreakpoint = o,
    i.emit("_beforeBreakpoint", a),
    t && (p ? (i.loopDestroy(),
    i.loopCreate(e),
    i.updateSlides()) : !h && y ? (i.loopCreate(e),
    i.updateSlides()) : h && !y && i.loopDestroy()),
    i.emit("breakpoint", a)
}
function Ut(i, e, t) {
    if (e === void 0 && (e = "window"),
    !i || e === "container" && !t)
        return;
    let s = !1;
    const n = B()
      , r = e === "window" ? n.innerHeight : t.clientHeight
      , o = Object.keys(i).map(l=>{
        if (typeof l == "string" && l.indexOf("@") === 0) {
            const a = parseFloat(l.substr(1));
            return {
                value: r * a,
                point: l
            }
        }
        return {
            value: l,
            point: l
        }
    }
    );
    o.sort((l,a)=>parseInt(l.value, 10) - parseInt(a.value, 10));
    for (let l = 0; l < o.length; l += 1) {
        const {point: a, value: c} = o[l];
        e === "window" ? n.matchMedia(`(min-width: ${c}px)`).matches && (s = a) : c <= t.clientWidth && (s = a)
    }
    return s || "max"
}
var Zt = {
    setBreakpoint: Kt,
    getBreakpoint: Ut
};
function Jt(i, e) {
    const t = [];
    return i.forEach(s=>{
        typeof s == "object" ? Object.keys(s).forEach(n=>{
            s[n] && t.push(e + n)
        }
        ) : typeof s == "string" && t.push(e + s)
    }
    ),
    t
}
function Qt() {
    const i = this
      , {classNames: e, params: t, rtl: s, el: n, device: r} = i
      , o = Jt(["initialized", t.direction, {
        "free-mode": i.params.freeMode && t.freeMode.enabled
    }, {
        autoheight: t.autoHeight
    }, {
        rtl: s
    }, {
        grid: t.grid && t.grid.rows > 1
    }, {
        "grid-column": t.grid && t.grid.rows > 1 && t.grid.fill === "column"
    }, {
        android: r.android
    }, {
        ios: r.ios
    }, {
        "css-mode": t.cssMode
    }, {
        centered: t.cssMode && t.centeredSlides
    }, {
        "watch-progress": t.watchSlidesProgress
    }], t.containerModifierClass);
    e.push(...o),
    n.classList.add(...e),
    i.emitContainerClasses()
}
function ei() {
    const i = this
      , {el: e, classNames: t} = i;
    e.classList.remove(...t),
    i.emitContainerClasses()
}
var ti = {
    addClasses: Qt,
    removeClasses: ei
};
function ii() {
    const i = this
      , {isLocked: e, params: t} = i
      , {slidesOffsetBefore: s} = t;
    if (s) {
        const n = i.slides.length - 1
          , r = i.slidesGrid[n] + i.slidesSizesGrid[n] + s * 2;
        i.isLocked = i.size > r
    } else
        i.isLocked = i.snapGrid.length === 1;
    t.allowSlideNext === !0 && (i.allowSlideNext = !i.isLocked),
    t.allowSlidePrev === !0 && (i.allowSlidePrev = !i.isLocked),
    e && e !== i.isLocked && (i.isEnd = !1),
    e !== i.isLocked && i.emit(i.isLocked ? "lock" : "unlock")
}
var si = {
    checkOverflow: ii
}
  , Ie = {
    init: !0,
    direction: "horizontal",
    oneWayMovement: !1,
    touchEventsTarget: "wrapper",
    initialSlide: 0,
    speed: 300,
    cssMode: !1,
    updateOnWindowResize: !0,
    resizeObserver: !0,
    nested: !1,
    createElements: !1,
    eventsPrefix: "swiper",
    enabled: !0,
    focusableElements: "input, select, option, textarea, button, video, label",
    width: null,
    height: null,
    preventInteractionOnTransition: !1,
    userAgent: null,
    url: null,
    edgeSwipeDetection: !1,
    edgeSwipeThreshold: 20,
    autoHeight: !1,
    setWrapperSize: !1,
    virtualTranslate: !1,
    effect: "slide",
    breakpoints: void 0,
    breakpointsBase: "window",
    spaceBetween: 0,
    slidesPerView: 1,
    slidesPerGroup: 1,
    slidesPerGroupSkip: 0,
    slidesPerGroupAuto: !1,
    centeredSlides: !1,
    centeredSlidesBounds: !1,
    slidesOffsetBefore: 0,
    slidesOffsetAfter: 0,
    normalizeSlideIndex: !0,
    centerInsufficientSlides: !1,
    watchOverflow: !0,
    roundLengths: !1,
    touchRatio: 1,
    touchAngle: 45,
    simulateTouch: !0,
    shortSwipes: !0,
    longSwipes: !0,
    longSwipesRatio: .5,
    longSwipesMs: 300,
    followFinger: !0,
    allowTouchMove: !0,
    threshold: 5,
    touchMoveStopPropagation: !1,
    touchStartPreventDefault: !0,
    touchStartForcePreventDefault: !1,
    touchReleaseOnEdges: !1,
    uniqueNavElements: !0,
    resistance: !0,
    resistanceRatio: .85,
    watchSlidesProgress: !1,
    grabCursor: !1,
    preventClicks: !0,
    preventClicksPropagation: !0,
    slideToClickedSlide: !1,
    loop: !1,
    loopAddBlankSlides: !0,
    loopAdditionalSlides: 0,
    loopPreventsSliding: !0,
    rewind: !1,
    allowSlidePrev: !0,
    allowSlideNext: !0,
    swipeHandler: null,
    noSwiping: !0,
    noSwipingClass: "swiper-no-swiping",
    noSwipingSelector: null,
    passiveListeners: !0,
    maxBackfaceHiddenSlides: 10,
    containerModifierClass: "swiper-",
    slideClass: "swiper-slide",
    slideBlankClass: "swiper-slide-blank",
    slideActiveClass: "swiper-slide-active",
    slideVisibleClass: "swiper-slide-visible",
    slideFullyVisibleClass: "swiper-slide-fully-visible",
    slideNextClass: "swiper-slide-next",
    slidePrevClass: "swiper-slide-prev",
    wrapperClass: "swiper-wrapper",
    lazyPreloaderClass: "swiper-lazy-preloader",
    lazyPreloadPrevNext: 0,
    runCallbacksOnInit: !0,
    _emitClasses: !1
};
function ri(i, e) {
    return function(s) {
        s === void 0 && (s = {});
        const n = Object.keys(s)[0]
          , r = s[n];
        if (typeof r != "object" || r === null) {
            F(e, s);
            return
        }
        if (i[n] === !0 && (i[n] = {
            enabled: !0
        }),
        n === "navigation" && i[n] && i[n].enabled && !i[n].prevEl && !i[n].nextEl && (i[n].auto = !0),
        ["pagination", "scrollbar"].indexOf(n) >= 0 && i[n] && i[n].enabled && !i[n].el && (i[n].auto = !0),
        !(n in i && "enabled"in r)) {
            F(e, s);
            return
        }
        typeof i[n] == "object" && !("enabled"in i[n]) && (i[n].enabled = !0),
        i[n] || (i[n] = {
            enabled: !1
        }),
        F(e, s)
    }
}
const ue = {
    eventsEmitter: tt,
    update: ut,
    translate: wt,
    transition: bt,
    slide: At,
    loop: Gt,
    grabCursor: $t,
    events: Yt,
    breakpoints: Zt,
    checkOverflow: si,
    classes: ti
}
  , pe = {};
class _ {
    constructor() {
        let e, t;
        for (var s = arguments.length, n = new Array(s), r = 0; r < s; r++)
            n[r] = arguments[r];
        n.length === 1 && n[0].constructor && Object.prototype.toString.call(n[0]).slice(8, -1) === "Object" ? t = n[0] : [e,t] = n,
        t || (t = {}),
        t = F({}, t),
        e && !t.el && (t.el = e);
        const o = K();
        if (t.el && typeof t.el == "string" && o.querySelectorAll(t.el).length > 1) {
            const d = [];
            return o.querySelectorAll(t.el).forEach(f=>{
                const u = F({}, t, {
                    el: f
                });
                d.push(new _(u))
            }
            ),
            d
        }
        const l = this;
        l.__swiper__ = !0,
        l.support = Ae(),
        l.device = Ue({
            userAgent: t.userAgent
        }),
        l.browser = Je(),
        l.eventsListeners = {},
        l.eventsAnyListeners = [],
        l.modules = [...l.__modules__],
        t.modules && Array.isArray(t.modules) && l.modules.push(...t.modules);
        const a = {};
        l.modules.forEach(d=>{
            d({
                params: t,
                swiper: l,
                extendParams: ri(t, a),
                on: l.on.bind(l),
                once: l.once.bind(l),
                off: l.off.bind(l),
                emit: l.emit.bind(l)
            })
        }
        );
        const c = F({}, Ie, a);
        return l.params = F({}, c, pe, t),
        l.originalParams = F({}, l.params),
        l.passedParams = F({}, t),
        l.params && l.params.on && Object.keys(l.params.on).forEach(d=>{
            l.on(d, l.params.on[d])
        }
        ),
        l.params && l.params.onAny && l.onAny(l.params.onAny),
        Object.assign(l, {
            enabled: l.params.enabled,
            el: e,
            classNames: [],
            slides: [],
            slidesGrid: [],
            snapGrid: [],
            slidesSizesGrid: [],
            isHorizontal() {
                return l.params.direction === "horizontal"
            },
            isVertical() {
                return l.params.direction === "vertical"
            },
            activeIndex: 0,
            realIndex: 0,
            isBeginning: !0,
            isEnd: !1,
            translate: 0,
            previousTranslate: 0,
            progress: 0,
            velocity: 0,
            animating: !1,
            cssOverflowAdjustment() {
                return Math.trunc(this.translate / 2 ** 23) * 2 ** 23
            },
            allowSlideNext: l.params.allowSlideNext,
            allowSlidePrev: l.params.allowSlidePrev,
            touchEventsData: {
                isTouched: void 0,
                isMoved: void 0,
                allowTouchCallbacks: void 0,
                touchStartTime: void 0,
                isScrolling: void 0,
                currentTranslate: void 0,
                startTranslate: void 0,
                allowThresholdMove: void 0,
                focusableElements: l.params.focusableElements,
                lastClickTime: 0,
                clickTimeout: void 0,
                velocities: [],
                allowMomentumBounce: void 0,
                startMoving: void 0,
                pointerId: null,
                touchId: null
            },
            allowClick: !0,
            allowTouchMove: l.params.allowTouchMove,
            touches: {
                startX: 0,
                startY: 0,
                currentX: 0,
                currentY: 0,
                diff: 0
            },
            imagesToLoad: [],
            imagesLoaded: 0
        }),
        l.emit("_swiper"),
        l.params.init && l.init(),
        l
    }
    getDirectionLabel(e) {
        return this.isHorizontal() ? e : {
            width: "height",
            "margin-top": "margin-left",
            "margin-bottom ": "margin-right",
            "margin-left": "margin-top",
            "margin-right": "margin-bottom",
            "padding-left": "padding-top",
            "padding-right": "padding-bottom",
            marginRight: "marginBottom"
        }[e]
    }
    getSlideIndex(e) {
        const {slidesEl: t, params: s} = this
          , n = W(t, `.${s.slideClass}, swiper-slide`)
          , r = be(n[0]);
        return be(e) - r
    }
    getSlideIndexByData(e) {
        return this.getSlideIndex(this.slides.filter(t=>t.getAttribute("data-swiper-slide-index") * 1 === e)[0])
    }
    recalcSlides() {
        const e = this
          , {slidesEl: t, params: s} = e;
        e.slides = W(t, `.${s.slideClass}, swiper-slide`)
    }
    enable() {
        const e = this;
        e.enabled || (e.enabled = !0,
        e.params.grabCursor && e.setGrabCursor(),
        e.emit("enable"))
    }
    disable() {
        const e = this;
        !e.enabled || (e.enabled = !1,
        e.params.grabCursor && e.unsetGrabCursor(),
        e.emit("disable"))
    }
    setProgress(e, t) {
        const s = this;
        e = Math.min(Math.max(e, 0), 1);
        const n = s.minTranslate()
          , o = (s.maxTranslate() - n) * e + n;
        s.translateTo(o, typeof t == "undefined" ? 0 : t),
        s.updateActiveIndex(),
        s.updateSlidesClasses()
    }
    emitContainerClasses() {
        const e = this;
        if (!e.params._emitClasses || !e.el)
            return;
        const t = e.el.className.split(" ").filter(s=>s.indexOf("swiper") === 0 || s.indexOf(e.params.containerModifierClass) === 0);
        e.emit("_containerClasses", t.join(" "))
    }
    getSlideClasses(e) {
        const t = this;
        return t.destroyed ? "" : e.className.split(" ").filter(s=>s.indexOf("swiper-slide") === 0 || s.indexOf(t.params.slideClass) === 0).join(" ")
    }
    emitSlidesClasses() {
        const e = this;
        if (!e.params._emitClasses || !e.el)
            return;
        const t = [];
        e.slides.forEach(s=>{
            const n = e.getSlideClasses(s);
            t.push({
                slideEl: s,
                classNames: n
            }),
            e.emit("_slideClass", s, n)
        }
        ),
        e.emit("_slideClasses", t)
    }
    slidesPerViewDynamic(e, t) {
        e === void 0 && (e = "current"),
        t === void 0 && (t = !1);
        const s = this
          , {params: n, slides: r, slidesGrid: o, slidesSizesGrid: l, size: a, activeIndex: c} = s;
        let d = 1;
        if (typeof n.slidesPerView == "number")
            return n.slidesPerView;
        if (n.centeredSlides) {
            let f = r[c] ? r[c].swiperSlideSize : 0, u;
            for (let p = c + 1; p < r.length; p += 1)
                r[p] && !u && (f += r[p].swiperSlideSize,
                d += 1,
                f > a && (u = !0));
            for (let p = c - 1; p >= 0; p -= 1)
                r[p] && !u && (f += r[p].swiperSlideSize,
                d += 1,
                f > a && (u = !0))
        } else if (e === "current")
            for (let f = c + 1; f < r.length; f += 1)
                (t ? o[f] + l[f] - o[c] < a : o[f] - o[c] < a) && (d += 1);
        else
            for (let f = c - 1; f >= 0; f -= 1)
                o[c] - o[f] < a && (d += 1);
        return d
    }
    update() {
        const e = this;
        if (!e || e.destroyed)
            return;
        const {snapGrid: t, params: s} = e;
        s.breakpoints && e.setBreakpoint(),
        [...e.el.querySelectorAll('[loading="lazy"]')].forEach(o=>{
            o.complete && Q(e, o)
        }
        ),
        e.updateSize(),
        e.updateSlides(),
        e.updateProgress(),
        e.updateSlidesClasses();
        function n() {
            const o = e.rtlTranslate ? e.translate * -1 : e.translate
              , l = Math.min(Math.max(o, e.maxTranslate()), e.minTranslate());
            e.setTranslate(l),
            e.updateActiveIndex(),
            e.updateSlidesClasses()
        }
        let r;
        if (s.freeMode && s.freeMode.enabled && !s.cssMode)
            n(),
            s.autoHeight && e.updateAutoHeight();
        else {
            if ((s.slidesPerView === "auto" || s.slidesPerView > 1) && e.isEnd && !s.centeredSlides) {
                const o = e.virtual && s.virtual.enabled ? e.virtual.slides : e.slides;
                r = e.slideTo(o.length - 1, 0, !1, !0)
            } else
                r = e.slideTo(e.activeIndex, 0, !1, !0);
            r || n()
        }
        s.watchOverflow && t !== e.snapGrid && e.checkOverflow(),
        e.emit("update")
    }
    changeDirection(e, t) {
        t === void 0 && (t = !0);
        const s = this
          , n = s.params.direction;
        return e || (e = n === "horizontal" ? "vertical" : "horizontal"),
        e === n || e !== "horizontal" && e !== "vertical" || (s.el.classList.remove(`${s.params.containerModifierClass}${n}`),
        s.el.classList.add(`${s.params.containerModifierClass}${e}`),
        s.emitContainerClasses(),
        s.params.direction = e,
        s.slides.forEach(r=>{
            e === "vertical" ? r.style.width = "" : r.style.height = ""
        }
        ),
        s.emit("changeDirection"),
        t && s.update()),
        s
    }
    changeLanguageDirection(e) {
        const t = this;
        t.rtl && e === "rtl" || !t.rtl && e === "ltr" || (t.rtl = e === "rtl",
        t.rtlTranslate = t.params.direction === "horizontal" && t.rtl,
        t.rtl ? (t.el.classList.add(`${t.params.containerModifierClass}rtl`),
        t.el.dir = "rtl") : (t.el.classList.remove(`${t.params.containerModifierClass}rtl`),
        t.el.dir = "ltr"),
        t.update())
    }
    mount(e) {
        const t = this;
        if (t.mounted)
            return !0;
        let s = e || t.params.el;
        if (typeof s == "string" && (s = document.querySelector(s)),
        !s)
            return !1;
        s.swiper = t,
        s.parentNode && s.parentNode.host && s.parentNode.host.nodeName === "SWIPER-CONTAINER" && (t.isElement = !0);
        const n = ()=>`.${(t.params.wrapperClass || "").trim().split(" ").join(".")}`;
        let o = (()=>s && s.shadowRoot && s.shadowRoot.querySelector ? s.shadowRoot.querySelector(n()) : W(s, n())[0])();
        return !o && t.params.createElements && (o = X("div", t.params.wrapperClass),
        s.append(o),
        W(s, `.${t.params.slideClass}`).forEach(l=>{
            o.append(l)
        }
        )),
        Object.assign(t, {
            el: s,
            wrapperEl: o,
            slidesEl: t.isElement && !s.parentNode.host.slideSlots ? s.parentNode.host : o,
            hostEl: t.isElement ? s.parentNode.host : s,
            mounted: !0,
            rtl: s.dir.toLowerCase() === "rtl" || j(s, "direction") === "rtl",
            rtlTranslate: t.params.direction === "horizontal" && (s.dir.toLowerCase() === "rtl" || j(s, "direction") === "rtl"),
            wrongRTL: j(o, "display") === "-webkit-box"
        }),
        !0
    }
    init(e) {
        const t = this;
        if (t.initialized || t.mount(e) === !1)
            return t;
        t.emit("beforeInit"),
        t.params.breakpoints && t.setBreakpoint(),
        t.addClasses(),
        t.updateSize(),
        t.updateSlides(),
        t.params.watchOverflow && t.checkOverflow(),
        t.params.grabCursor && t.enabled && t.setGrabCursor(),
        t.params.loop && t.virtual && t.params.virtual.enabled ? t.slideTo(t.params.initialSlide + t.virtual.slidesBefore, 0, t.params.runCallbacksOnInit, !1, !0) : t.slideTo(t.params.initialSlide, 0, t.params.runCallbacksOnInit, !1, !0),
        t.params.loop && t.loopCreate(),
        t.attachEvents();
        const n = [...t.el.querySelectorAll('[loading="lazy"]')];
        return t.isElement && n.push(...t.hostEl.querySelectorAll('[loading="lazy"]')),
        n.forEach(r=>{
            r.complete ? Q(t, r) : r.addEventListener("load", o=>{
                Q(t, o.target)
            }
            )
        }
        ),
        me(t),
        t.initialized = !0,
        me(t),
        t.emit("init"),
        t.emit("afterInit"),
        t
    }
    destroy(e, t) {
        e === void 0 && (e = !0),
        t === void 0 && (t = !0);
        const s = this
          , {params: n, el: r, wrapperEl: o, slides: l} = s;
        return typeof s.params == "undefined" || s.destroyed || (s.emit("beforeDestroy"),
        s.initialized = !1,
        s.detachEvents(),
        n.loop && s.loopDestroy(),
        t && (s.removeClasses(),
        r.removeAttribute("style"),
        o.removeAttribute("style"),
        l && l.length && l.forEach(a=>{
            a.classList.remove(n.slideVisibleClass, n.slideFullyVisibleClass, n.slideActiveClass, n.slideNextClass, n.slidePrevClass),
            a.removeAttribute("style"),
            a.removeAttribute("data-swiper-slide-index")
        }
        )),
        s.emit("destroy"),
        Object.keys(s.eventsListeners).forEach(a=>{
            s.off(a)
        }
        ),
        e !== !1 && (s.el.swiper = null,
        _e(s)),
        s.destroyed = !0),
        null
    }
    static extendDefaults(e) {
        F(pe, e)
    }
    static get extendedDefaults() {
        return pe
    }
    static get defaults() {
        return Ie
    }
    static installModule(e) {
        _.prototype.__modules__ || (_.prototype.__modules__ = []);
        const t = _.prototype.__modules__;
        typeof e == "function" && t.indexOf(e) < 0 && t.push(e)
    }
    static use(e) {
        return Array.isArray(e) ? (e.forEach(t=>_.installModule(t)),
        _) : (_.installModule(e),
        _)
    }
}
Object.keys(ue).forEach(i=>{
    Object.keys(ue[i]).forEach(e=>{
        _.prototype[e] = ue[i][e]
    }
    )
}
);
_.use([Qe, et]);
function ni(i) {
    const {effect: e, swiper: t, on: s, setTranslate: n, setTransition: r, overwriteParams: o, perspective: l, recreateShadows: a, getEffectParams: c} = i;
    s("beforeInit", ()=>{
        if (t.params.effect !== e)
            return;
        t.classNames.push(`${t.params.containerModifierClass}${e}`),
        l && l() && t.classNames.push(`${t.params.containerModifierClass}3d`);
        const f = o ? o() : {};
        Object.assign(t.params, f),
        Object.assign(t.originalParams, f)
    }
    ),
    s("setTranslate", ()=>{
        t.params.effect === e && n()
    }
    ),
    s("setTransition", (f,u)=>{
        t.params.effect === e && r(u)
    }
    ),
    s("transitionEnd", ()=>{
        if (t.params.effect === e && a) {
            if (!c || !c().slideShadows)
                return;
            t.slides.forEach(f=>{
                f.querySelectorAll(".swiper-slide-shadow-top, .swiper-slide-shadow-right, .swiper-slide-shadow-bottom, .swiper-slide-shadow-left").forEach(u=>u.remove())
            }
            ),
            a()
        }
    }
    );
    let d;
    s("virtualUpdate", ()=>{
        t.params.effect === e && (t.slides.length || (d = !0),
        requestAnimationFrame(()=>{
            d && t.slides && t.slides.length && (n(),
            d = !1)
        }
        ))
    }
    )
}
function ai(i) {
    let {swiper: e, extendParams: t, on: s} = i;
    t({
        cubeEffect: {
            slideShadows: !0,
            shadow: !0,
            shadowOffset: 20,
            shadowScale: .94
        }
    });
    const n = (a,c,d)=>{
        let f = d ? a.querySelector(".swiper-slide-shadow-left") : a.querySelector(".swiper-slide-shadow-top")
          , u = d ? a.querySelector(".swiper-slide-shadow-right") : a.querySelector(".swiper-slide-shadow-bottom");
        f || (f = X("div", `swiper-slide-shadow-cube swiper-slide-shadow-${d ? "left" : "top"}`.split(" ")),
        a.append(f)),
        u || (u = X("div", `swiper-slide-shadow-cube swiper-slide-shadow-${d ? "right" : "bottom"}`.split(" ")),
        a.append(u)),
        f && (f.style.opacity = Math.max(-c, 0)),
        u && (u.style.opacity = Math.max(c, 0))
    }
    ;
    ni({
        effect: "cube",
        swiper: e,
        on: s,
        setTranslate: ()=>{
            const {el: a, wrapperEl: c, slides: d, width: f, height: u, rtlTranslate: p, size: h, browser: T} = e
              , y = e.params.cubeEffect
              , g = e.isHorizontal()
              , P = e.virtual && e.params.virtual.enabled;
            let v = 0, m;
            y.shadow && (g ? (m = e.wrapperEl.querySelector(".swiper-cube-shadow"),
            m || (m = X("div", "swiper-cube-shadow"),
            e.wrapperEl.append(m)),
            m.style.height = `${f}px`) : (m = a.querySelector(".swiper-cube-shadow"),
            m || (m = X("div", "swiper-cube-shadow"),
            a.append(m))));
            for (let O = 0; O < d.length; O += 1) {
                const G = d[O];
                let L = O;
                P && (L = parseInt(G.getAttribute("data-swiper-slide-index"), 10));
                let D = L * 90
                  , S = Math.floor(D / 360);
                p && (D = -D,
                S = Math.floor(-D / 360));
                const b = Math.max(Math.min(G.progress, 1), -1);
                let x = 0
                  , E = 0
                  , z = 0;
                L % 4 === 0 ? (x = -S * 4 * h,
                z = 0) : (L - 1) % 4 === 0 ? (x = 0,
                z = -S * 4 * h) : (L - 2) % 4 === 0 ? (x = h + S * 4 * h,
                z = h) : (L - 3) % 4 === 0 && (x = -h,
                z = 3 * h + h * 4 * S),
                p && (x = -x),
                g || (E = x,
                x = 0);
                const $ = `rotateX(${g ? 0 : -D}deg) rotateY(${g ? D : 0}deg) translate3d(${x}px, ${E}px, ${z}px)`;
                b <= 1 && b > -1 && (v = L * 90 + b * 90,
                p && (v = -L * 90 - b * 90),
                e.browser && e.browser.isSafari && Math.abs(v) / 90 % 2 === 1 && (v += .001)),
                G.style.transform = $,
                y.slideShadows && n(G, b, g)
            }
            if (c.style.transformOrigin = `50% 50% -${h / 2}px`,
            c.style["-webkit-transform-origin"] = `50% 50% -${h / 2}px`,
            y.shadow)
                if (g)
                    m.style.transform = `translate3d(0px, ${f / 2 + y.shadowOffset}px, ${-f / 2}px) rotateX(89.99deg) rotateZ(0deg) scale(${y.shadowScale})`;
                else {
                    const O = Math.abs(v) - Math.floor(Math.abs(v) / 90) * 90
                      , G = 1.5 - (Math.sin(O * 2 * Math.PI / 360) / 2 + Math.cos(O * 2 * Math.PI / 360) / 2)
                      , L = y.shadowScale
                      , D = y.shadowScale / G
                      , S = y.shadowOffset;
                    m.style.transform = `scale3d(${L}, 1, ${D}) translate3d(0px, ${u / 2 + S}px, ${-u / 2 / D}px) rotateX(-89.99deg)`
                }
            const M = (T.isSafari || T.isWebView) && T.needPerspectiveFix ? -h / 2 : 0;
            c.style.transform = `translate3d(0px,0,${M}px) rotateX(${e.isHorizontal() ? 0 : v}deg) rotateY(${e.isHorizontal() ? -v : 0}deg)`,
            c.style.setProperty("--swiper-cube-translate-z", `${M}px`)
        }
        ,
        setTransition: a=>{
            const {el: c, slides: d} = e;
            if (d.forEach(f=>{
                f.style.transitionDuration = `${a}ms`,
                f.querySelectorAll(".swiper-slide-shadow-top, .swiper-slide-shadow-right, .swiper-slide-shadow-bottom, .swiper-slide-shadow-left").forEach(u=>{
                    u.style.transitionDuration = `${a}ms`
                }
                )
            }
            ),
            e.params.cubeEffect.shadow && !e.isHorizontal()) {
                const f = c.querySelector(".swiper-cube-shadow");
                f && (f.style.transitionDuration = `${a}ms`)
            }
        }
        ,
        recreateShadows: ()=>{
            const a = e.isHorizontal();
            e.slides.forEach(c=>{
                const d = Math.max(Math.min(c.progress, 1), -1);
                n(c, d, a)
            }
            )
        }
        ,
        getEffectParams: ()=>e.params.cubeEffect,
        perspective: ()=>!0,
        overwriteParams: ()=>({
            slidesPerView: 1,
            slidesPerGroup: 1,
            watchSlidesProgress: !0,
            resistanceRatio: 0,
            spaceBetween: 0,
            centeredSlides: !1,
            virtualTranslate: !0
        })
    })
}
function oi(i, e={}) {
    const t = i.querySelector(".swiper")
      , {autoplayDuration: s=5e3, Swiper: n, EffectCube: r, onSlidesIndexesChange: o, onAutoplayStart: l, onAutoplayStop: a, onEnd: c} = e;
    let {enabled: d=!0} = e, f = 0, u, p;
    const h = [];
    let T, y, g, P, v, m, M, O, G;
    const L = (w,I)=>{
        const C = h.indexOf(w);
        let A = typeof I == "undefined" ? s : I
          , k = parseInt(w.slides[w.activeIndex].getAttribute("data-duration"), 10);
        const q = w.slides[w.activeIndex].querySelector("video");
        return Number.isNaN(k) && q && (k = q.duration * 1e3),
        !Number.isNaN(k) && k > 0 && typeof I == "undefined" && (A = k),
        M = A,
        w.storiesSliderAutoplayTimeout = setTimeout(()=>{
            if (!w.isEnd)
                w.slideNext();
            else {
                if (f !== C)
                    return;
                u.isEnd ? c && c() : u.slideNext()
            }
        }
        , A),
        l && l(w),
        A
    }
      , D = w=>{
        clearTimeout(w.storiesSliderAutoplayTimeout),
        a && a(w)
    }
      , S = w=>{
        D(w);
        const I = w.slides[w.activeIndex].querySelector("video");
        I && (cancelAnimationFrame(p),
        I.pause());
        const C = M || s;
        let A = parseInt(w.slides[w.activeIndex].getAttribute("data-duration"), 10);
        if (Number.isNaN(A) && (A = void 0),
        !A && I && (A = I.duration * 1e3),
        M = C - (new Date().getTime() - m),
        w.isEnd && M < 0)
            return;
        M < 0 && (M = 0);
        const k = 1 - M / (A || s)
          , q = w.el.querySelector(`.stories-slider-pagination-bullet:nth-child(${w.activeIndex + 1})`);
        q.querySelector("span").remove(),
        q.insertAdjacentHTML("beforeend", `<span style="transform:translateX(${-100 + k * 100}%)"></span>`)
    }
      , b = w=>{
        if (w.isEnd && M < 0)
            return;
        m = new Date().getTime(),
        L(w, M);
        const I = w.slides[w.activeIndex].querySelector("video");
        if (I)
            try {
                p = requestAnimationFrame(()=>{
                    I.play()
                }
                )
            } catch {}
        const C = w.el.querySelector(`.stories-slider-pagination-bullet:nth-child(${w.activeIndex + 1}) > span`);
        C.style.transform = "translateX(0%)",
        C.style.transitionDuration = `${M}ms`
    }
      , x = w=>{
        D(w),
        L(w),
        m = new Date().getTime();
        const I = w.el.querySelector(".stories-slider-pagination-bullet-current");
        I && I.classList.remove("stories-slider-pagination-bullet-current");
        const C = w.el.querySelector(`.stories-slider-pagination-bullet:nth-child(${w.activeIndex + 1})`)
          , A = w.slides[w.activeIndex].querySelector("video");
        if (A) {
            A.currentTime = 0;
            try {
                p = requestAnimationFrame(()=>{
                    A.play()
                }
                )
            } catch {}
        }
        w.slides.forEach(V=>{
            V.querySelectorAll("video").forEach(N=>{
                N !== A && (N.currentTime = 0,
                A || cancelAnimationFrame(p),
                N.pause())
            }
            )
        }
        ),
        h.filter((V,N)=>N !== f).forEach(V=>{
            V.el.querySelectorAll("video").forEach(N=>{
                A || cancelAnimationFrame(p),
                N.pause()
            }
            )
        }
        );
        const k = [...C.parentElement.children]
          , q = [...k].filter((V,N)=>N < k.indexOf(C))
          , ne = [...k].filter((V,N)=>N > k.indexOf(C));
        q.forEach(V=>{
            V.classList.add("stories-slider-pagination-bullet-viewed"),
            V.querySelectorAll("span").forEach(N=>N.remove()),
            V.insertAdjacentHTML("beforeend", "<span></span>")
        }
        ),
        ne.forEach(V=>{
            V.classList.remove("stories-slider-pagination-bullet-viewed", "stories-slider-pagination-bullet-current"),
            V.querySelectorAll("span").forEach(N=>N.remove()),
            V.insertAdjacentHTML("beforeend", "<span></span>")
        }
        ),
        C.classList.remove("stories-slider-pagination-bullet-viewed"),
        C.classList.add("stories-slider-pagination-bullet-current"),
        [...C.children].forEach(V=>V.remove()),
        C.insertAdjacentHTML("beforeend", "<span></span>"),
        C.clientWidth,
        C.querySelector("span").style.transform = "translateX(0%)",
        C.querySelector("span").style.transitionDuration = `${M}ms`,
        o && (cancelAnimationFrame(T),
        T = requestAnimationFrame(()=>{
            o(f, w.activeIndex)
        }
        ))
    }
      , E = ()=>{
        const w = ()=>{
            i.classList.add("stories-slider-perspective")
        }
          , I = ()=>{
            i.classList.remove("stories-slider-perspective")
        }
        ;
        u = new n(t,{
            modules: typeof r != "undefined" ? [r] : [],
            effect: "cube",
            speed: 500,
            threshold: 5,
            cubeEffect: {
                shadow: !1
            },
            observer: !0,
            on: {
                transitionStart() {
                    I()
                },
                sliderFirstMove() {
                    I()
                },
                transitionEnd() {
                    w()
                },
                init(C) {
                    C.params.resistanceRatio = .5,
                    w()
                },
                slideChange() {
                    G = !1;
                    const C = h[f];
                    f = u.activeIndex;
                    const A = h[f];
                    D(C),
                    L(A),
                    x(A)
                }
            }
        })
    }
      , z = w=>{
        const I = w.querySelectorAll(".swiper-slide")
          , C = document.createElement("div");
        C.classList.add("stories-slider-pagination");
        for (let A = 0; A < I.length; A += 1) {
            const k = document.createElement("div");
            k.classList.add("stories-slider-pagination-bullet"),
            k.appendChild(document.createElement("span")),
            C.appendChild(k)
        }
        w.appendChild(C)
    }
      , $ = w=>{
        w.el.querySelectorAll(".stories-slider-pagination, .stories-slider-pagination-bullet").forEach(I=>I.remove())
    }
      , H = (w,I)=>{
        w.querySelectorAll(".swiper-slide").forEach(A=>{
            const k = document.createElement("div")
              , q = document.createElement("div");
            k.classList.add("stories-slider-button", "stories-slider-button-prev"),
            q.classList.add("stories-slider-button", "stories-slider-button-next"),
            A.appendChild(k),
            A.appendChild(q);
            const ne = ()=>{
                if (!(v > 200)) {
                    if (I.isBeginning) {
                        u.slidePrev();
                        return
                    }
                    I.slidePrev()
                }
            }
              , V = ()=>{
                if (!(v > 200)) {
                    if (I.isEnd) {
                        u.slideNext();
                        return
                    }
                    I.slideNext()
                }
            }
            ;
            k.addEventListener("click", ne),
            q.addEventListener("click", V)
        }
        )
    }
      , ie = w=>{
        w.el.querySelectorAll(".stories-slider-button").forEach(I=>I.remove())
    }
      , U = ()=>{
        i.querySelectorAll(".swiper .swiper").forEach((w,I)=>{
            const C = new n(w,{
                speed: 1,
                nested: !0,
                allowTouchMove: !1,
                observer: !0,
                on: {
                    touchStart(A) {
                        G || (y = !0,
                        O = !1,
                        g = new Date().getTime(),
                        P = setTimeout(()=>{
                            O = !0,
                            S(A)
                        }
                        , 200))
                    },
                    touchEnd(A) {
                        G || (clearTimeout(P),
                        f === I && (!y || (v = new Date().getTime() - g,
                        O && b(A),
                        O = !1,
                        y = !1)))
                    },
                    init(A) {
                        !d || (f !== I ? D(A) : requestAnimationFrame(()=>{
                            x(A)
                        }
                        ))
                    },
                    slideChange(A) {
                        G = !1,
                        x(A)
                    }
                }
            });
            z(w),
            H(w, C),
            h.push(C)
        }
        )
    }
    ;
    return E(),
    U(),
    {
        el: i,
        mainSwiper: u,
        subSwipers: h,
        destroy: ()=>{
            u && u.destroy && u.destroy(),
            h.forEach(w=>{
                D(w),
                $(w),
                ie(w),
                w.destroy && w.destroy()
            }
            )
        }
        ,
        slideTo: (w,I)=>{
            if (u && u.slideTo && !u.destroyed && u.slideTo(w, 0),
            typeof I != "undefined") {
                const C = h[w];
                C.slideTo && !C.destroyed && (C.activeIndex === I ? x(C) : C.slideTo(I, 0))
            }
        }
        ,
        enable: ()=>{
            d || h.forEach((w,I)=>{
                I === f && x(w)
            }
            )
        }
        ,
        disable: ()=>{
            d = !1,
            h.forEach((w,I)=>{
                w.el.querySelectorAll("video").forEach(C=>{
                    cancelAnimationFrame(p),
                    C.pause()
                }
                ),
                I === f ? S(w) : D(w)
            }
            )
        }
        ,
        pause: (w=!1)=>{
            G = !!w,
            S(h[f])
        }
        ,
        resume: ()=>{
            G = !1,
            b(h[f])
        }
    }
}
const R = document.querySelector(".stories-slider")
  , Y = oi(R, {
    Swiper: _,
    EffectCube: ai,
    autoplayDuration: 5e3,
    enabled: !1,
    onSlidesIndexesChange(i, e) {
        console.log({
            mainIndex: i,
            subIndex: e
        })
    },
    onEnd() {
        Y.disable(),
        R.classList.add("stories-slider-out")
    }
});
document.querySelectorAll(".demo-stories a").forEach((i,e)=>{
    i.addEventListener("click", t=>{
        t.preventDefault(),
        R.classList.add("stories-slider-in"),
        Y.enable(),
        Y.slideTo(e, 0)
    }
    )
}
);
document.querySelectorAll(".demo-post-avatar").forEach(i=>{
    const e = parseInt(i.getAttribute("data-user-index"), 10);
    i.addEventListener("click", t=>{
        t.preventDefault(),
        R.classList.add("stories-slider-in"),
        Y.enable(),
        Y.slideTo(e, 0)
    }
    )
}
);
R.addEventListener("click", i=>{
    i.target.matches(".stories-slider-close-button") && (Y.disable(),
    R.classList.add("stories-slider-out"))
}
);
R.addEventListener("animationend", ()=>{
    R.classList.contains("stories-slider-out") && (R.classList.remove("stories-slider-in"),
    R.classList.remove("stories-slider-out"))
}
);
