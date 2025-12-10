// Captura de canvas usando html2canvas
window.capturarCanvas = function (elemento) {
    return new Promise((resolve, reject) => {
        try {
            // Usar html2canvas para capturar el elemento
            html2canvas(elemento, {
                backgroundColor: '#ffffff',
                scale: 2,
                logging: false
            }).then(canvas => {
                const imagenBase64 = canvas.toDataURL('image/png');
                // Extraer solo la parte base64
                const base64 = imagenBase64.split(',')[1];
                resolve(base64);
            }).catch(error => {
                reject(error);
            });
        } catch (error) {
            reject(error);
        }
    });
};

//<script>
//    window.capturarCanvas = function (elemento) {
//            return new Promise((resolve, reject) => {
//                try {
//        // Usar html2canvas para capturar el elemento
//        html2canvas(elemento, {
//            backgroundColor: '#ffffff',
//            scale: 2,
//            logging: false
//        }).then(canvas => {
//            const imagenBase64 = canvas.toDataURL('image/png');
//            // Extraer solo la parte base64
//            const base64 = imagenBase64.split(',')[1];
//            resolve(base64);
//        }).catch(error => {
//            reject(error);
//        });
//                } catch (error) {
//        reject(error);
//                }
//            });
//        };
//</script>