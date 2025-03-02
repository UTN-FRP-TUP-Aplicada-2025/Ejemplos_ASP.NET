

https://learn.microsoft.com/en-us/answers/questions/1613062/reload-the-page-to-restore-functionality-blazor-se?page=1#answers



mudblazor
https://www.youtube.com/watch?v=9Q2fL7iJvdo

varios formularios
https://www.youtube.com/watch?v=oBofp1QeGVQ



 BlazorStrap (Bootstrap) y MudBlazor (Material) para las bibliotecas de componentes nativos de Blazor.

https://stackoverflow.com/questions/77590322/blazor-web-app-net-8-javascript-not-executed-on-page-change

https://www.youtube.com/watch?v=3hVqINoW8h4


# templates
https://stackoverflow.com/questions/77590322/blazor-web-app-net-8-javascript-not-executed-on-page-change


https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-9.0&tabs=visual-studio-code

https://learn.microsoft.com/en-us/aspnet/core/blazor/security/additional-scenarios?view=aspnetcore-9.0#pass-tokens-to-a-server-side-blazor-app

https://learn.microsoft.com/en-us/aspnet/core/blazor/security/additional-scenarios?view=aspnetcore-9.0#circuit-handler-to-capture-users-for-custom-services


using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;


https://www.youtube.com/watch?v=K8dJh-aqEXw&list=PL0kIvpOlieSNdIPZbn-mO15YIjRHY2wI9&index=2


https://learn.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-8.0

https://learn.microsoft.com/en-us/aspnet/core/security/authorization/introduction?view=aspnetcore-8.0

https://learn.microsoft.com/en-us/aspnet/core/security/authorization/simple?view=aspnetcore-8.0


//window.initializeTemplate = () => {
//    console.log("Inicializando template...");

//    /**
//     * Easy selector helper function
//     */
//    const select = (el, all = false) => {
//        if (!el) return null;
//        el = el.trim();
//        return all ? [...document.querySelectorAll(el)] : document.querySelector(el);
//    };

//    /**
//     * Easy event listener function
//     */
//    const on = (type, el, listener, all = false) => {
//        let elements = select(el, all);
//        if (!elements) return;
//        if (all) {
//            elements.forEach(e => e.addEventListener(type, listener));
//        } else {
//            elements.addEventListener(type, listener);
//        }
//    };

//    /**
//     * Sidebar toggle
//     */
//    on('click', '.toggle-sidebar-btn', () => {
//        select('body')?.classList.toggle('toggle-sidebar');
//    });

//    /**
//     * Search bar toggle
//     */
//    on('click', '.search-bar-toggle', () => {
//        select('.search-bar')?.classList.toggle('search-bar-show');
//    });

//    /**
//     * Navbar links active state on scroll
//     */
//    let navbarlinks = select('#navbar .scrollto', true);
//    const navbarlinksActive = () => {
//        let position = window.scrollY + 200;
//        navbarlinks.forEach(navbarlink => {
//            if (!navbarlink.hash) return;
//            let section = select(navbarlink.hash);
//            if (!section) return;
//            navbarlink.classList.toggle('active', position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight));
//        });
//    };
//    window.addEventListener('load', navbarlinksActive);
//    on('scroll', document, navbarlinksActive);

//    ///**
//    // * Toggle .header-scrolled class to #header when page is scrolled
//    // */
//    //let selectHeader = select('#header');
//    //if (selectHeader) {
//    //    const headerScrolled = () => {
//    //        selectHeader.classList.toggle('header-scrolled', window.scrollY > 100);
//    //    };
//    //    window.addEventListener('load', headerScrolled);
//    //    on('scroll', document, headerScrolled);
//    //}

//    ///**
//    // * Back to top button
//    // */
//    //let backtotop = select('.back-to-top');
//    //if (backtotop) {
//    //    const toggleBacktotop = () => {
//    //        backtotop.classList.toggle('active', window.scrollY > 100);
//    //    };
//    //    window.addEventListener('load', toggleBacktotop);
//    //    on('scroll', document, toggleBacktotop);
//    //}

//    ///**
//    // * Initiate tooltips
//    // */
//    //var tooltipTriggerList = [...document.querySelectorAll('[data-bs-toggle="tooltip"]')];
//    //tooltipTriggerList.forEach(el => new bootstrap.Tooltip(el));

//    ///**
//    // * Initiate TinyMCE Editor
//    // */
//    //if (typeof tinymce !== 'undefined') {
//    //    tinymce.init({
//    //        selector: 'textarea.tinymce-editor',
//    //        plugins: 'preview autolink fullscreen image link media table',
//    //        menubar: 'file edit view insert format tools table',
//    //        toolbar: 'undo redo | formatselect | bold italic backcolor | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | removeformat',
//    //        height: 600,
//    //        content_css: 'default',
//    //    });
//    //}

//    ///**
//    // * Initiate Bootstrap validation check
//    // */
//    //document.querySelectorAll('.needs-validation').forEach(form => {
//    //    form.addEventListener('submit', event => {
//    //        if (!form.checkValidity()) {
//    //            event.preventDefault();
//    //            event.stopPropagation();
//    //        }
//    //        form.classList.add('was-validated');
//    //    }, false);
//    //});

//    ///**
//    // * Autoresize echart charts
//    // */
//    //const mainContainer = select('#main');
//    //if (mainContainer) {
//    //    setTimeout(() => {
//    //        new ResizeObserver(() => {
//    //            select('.echart', true).forEach(getEchart => {
//    //                let instance = echarts.getInstanceByDom(getEchart);
//    //                if (instance) instance.resize();
//    //            });
//    //        }).observe(mainContainer);
//    //    }, 200);
//    //}
//};


initializeTemplate = () => {
    console.log("Inicializando template...");

    /**
     * Easy selector helper function
     */
    const select = (el, all = false) => {
        el = el.trim();
        if (all) {
            return [...document.querySelectorAll(el)];
        } else {
            return document.querySelector(el);
        }
    };

    /**
     * Easy event listener function
     */
    const on = (type, el, listener, all = false) => {
        if (all) {
            select(el, all).forEach(e => e.addEventListener(type, listener));
        } else {
            select(el, all).addEventListener(type, listener);
        }
    };

    /**
     * Sidebar toggle
     */
    if (select('.toggle-sidebar-btn')) {
        on('click', '.toggle-sidebar-btn', function (e) {
            select('body').classList.toggle('toggle-sidebar');
        });
    }

    /**
     * Search bar toggle
     */
    if (select('.search-bar-toggle')) {
        on('click', '.search-bar-toggle', function (e) {
            select('.search-bar').classList.toggle('search-bar-show');
        });
    }

    /**
     * Navbar links active state on scroll
     */
    let navbarlinks = select('#navbar .scrollto', true);
    const navbarlinksActive = () => {
        let position = window.scrollY + 200;
        navbarlinks.forEach(navbarlink => {
            if (!navbarlink.hash) return;
            let section = select(navbarlink.hash);
            if (!section) return;
            if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                navbarlink.classList.add('active');
            } else {
                navbarlink.classList.remove('active');
            }
        });
    };
    window.addEventListener('load', navbarlinksActive);
    document.addEventListener('scroll', navbarlinksActive);

    /**
     * Back to top button
     */
    let backtotop = select('.back-to-top');
    if (backtotop) {
        const toggleBacktotop = () => {
            if (window.scrollY > 100) {
                backtotop.classList.add('active');
            } else {
                backtotop.classList.remove('active');
            }
        };
        window.addEventListener('load', toggleBacktotop);
        document.addEventListener('scroll', toggleBacktotop);
    }

    /**
     * Initiate tooltips
     */
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })

    /**
     * Initiate quill editors
     */
    if (select('.quill-editor-default')) {
        new Quill('.quill-editor-default', {
            theme: 'snow'
        });
    }

    if (select('.quill-editor-bubble')) {
        new Quill('.quill-editor-bubble', {
            theme: 'bubble'
        });
    }

    if (select('.quill-editor-full')) {
        new Quill(".quill-editor-full", {
            modules: {
                toolbar: [
                    [{
                        font: []
                    }, {
                        size: []
                    }],
                    ["bold", "italic", "underline", "strike"],
                    [{
                        color: []
                    },
                    {
                        background: []
                    }
                    ],
                    [{
                        script: "super"
                    },
                    {
                        script: "sub"
                    }
                    ],
                    [{
                        list: "ordered"
                    },
                    {
                        list: "bullet"
                    },
                    {
                        indent: "-1"
                    },
                    {
                        indent: "+1"
                    }
                    ],
                    ["direction", {
                        align: []
                    }],
                    ["link", "image", "video"],
                    ["clean"]
                ]
            },
            theme: "snow"
        });
    }

    /**
     * Initiate Datatables
     */
    //const datatables = select('.datatable', true)
    //datatables.forEach(datatable => {
    //    new simpleDatatables.DataTable(datatable, {
    //        perPageSelect: [5, 10, 15, ["All", -1]],
    //        columns: [{
    //            select: 2,
    //            sortSequence: ["desc", "asc"]
    //        },
    //        {
    //            select: 3,
    //            sortSequence: ["desc"]
    //        },
    //        {
    //            select: 4,
    //            cellClass: "green",
    //            headerClass: "red"
    //        }
    //        ]
    //    });
    //})


    console.log("Template inicializado.");
};


