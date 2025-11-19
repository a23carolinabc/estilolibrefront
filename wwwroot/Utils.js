let manejadoresActivos = {};
var Utils = {

    AbrirVentana: function (strUrl) 
    {
        window.open(strUrl, '_blank');
        return false;
    },

    ScrollTo: function (claseElemento) {
        var elemento = document.getElementsByClassName(claseElemento);
        if (elemento[0] != null && elemento != undefined) {
            var label = elemento[0].closest("label");
            var div = label.nextElementSibling;
            var input = div.firstElementChild;
            if (input != null) { input.focus(); }
            elemento[0].scrollIntoView({
                behavior: 'smooth'
            });
        }    
    },

    DarFoco: function () {
        var select = document.querySelector("form select");
        if (select != null && select != undefined) {
            select.focus()
        } else {
            document.querySelector("form input").focus();
        }
    },

    AbrirDialog: function (PopUpId) {
        var dialog = document.getElementById(PopUpId);
        if (dialog != null && dialog != undefined) {
            dialog.show();
        }
    },

    AbrirDialogModal: function (PopUpId) {
        var dialog = document.getElementById(PopUpId);
        if (dialog != null && dialog != undefined) {
            dialog.showModal();
        }
    },

    CerrarDialog: function (PopUpId) {
        var dialog = document.getElementById(PopUpId);
        if (dialog != null && dialog != undefined) {
            dialog.close();
        }
    },    

    CerrarAlHacerClickFuera: function (elementoId, dotNetHelper) {

        const elemento = document.getElementById(elementoId);
        if (!elemento) return;

        if (manejadoresActivos[elementoId]) {
            document.removeEventListener('click', manejadoresActivos[elementoId]);
        }

        const ClickFuera = function (event) {
            if (!elemento.contains(event.target)) {               
                dotNetHelper.invokeMethodAsync('CerrarSubMenu');
                document.removeEventListener('click', ClickFuera);
                delete manejadoresActivos[elementoId];
            }
        }

        // Se registra el listener
        setTimeout(() => {
            document.addEventListener('click', ClickFuera);
            manejadoresActivos[elementoId] = ClickFuera;
        }, 0);
    },

    Scroll: function (dotNetHelper, element) {
        const observer = new IntersectionObserver(entries => {
            if (entries[0].isIntersecting) {
                dotNetHelper.invokeMethodAsync("OnScrollAlFinal");
            }
        }, {
            rootMargin: '0px',
            threshold: 1.0
        });

        const sentinel = document.createElement('div');
        sentinel.style.height = '1px';
        element.appendChild(sentinel);
        observer.observe(sentinel);
    }
};
