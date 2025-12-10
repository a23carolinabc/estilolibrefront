// Eliminación del fondo de las imágenes usando @imgly/background-removal
import * as eliminacionFondo from 'https://esm.sh/@imgly/background-removal@1.7.0';

window.eliminarFondo = async function (imagenDatos) {
    try {
        console.log('Iniciando eliminación de fondo...');

        if (!imagenDatos) {
            throw new Error('No se proporcionó imagen');
        }

        // Convertir dataURL a Blob.
        const respuesta = await fetch(imagenDatos);
        const blob = await respuesta.blob();

        // Llamar a removeBackground.
        const resultadoBlob = await eliminacionFondo.removeBackground(blob, {
            model: 'small',  // Modelo pequeño == más rápido
            debug: true,
            progress: (key, current, total) => {
                const porcentaje = Math.round((current / total) * 100);
                console.log(`Progreso ${key}: ${porcentaje}%`);
            }
        });

        // Convertir resultado a dataURL.
        return await new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.onloadend = () => resolve(reader.result);
            reader.onerror = reject;
            reader.readAsDataURL(resultadoBlob);
        });

    } catch (err) {
        console.error('Error en la librería de eliminación de fondo:', err);
        throw err;
    }
};

console.log('Eliminación de fondo disponible');


//<script type="module">
//        // Descargar librería js.
//    import * as eliminacionFondo from 'https://esm.sh/@imgly/background-removal@1.7.0';

//    window.eliminarFondo = async function (imagenDatos) {
//            try {
//        console.log('Iniciando eliminación de fondo...');

//    if (!imagenDatos) {
//                    throw new Error('No se proporcionó imagen');
//                }

//    // Convertir dataURL a Blob.
//    const respuesta = await fetch(imagenDatos);
//    const blob = await respuesta.blob();

//    // Llamar a removeBackground.
//    const resultadoBlob = await eliminacionFondo.removeBackground(blob, {
//        model: 'small',  // Modelo pequeño == más rápido
//    debug: true,
//                    progress: (key, current, total) => {
//                        const porcentaje = Math.round((current / total) * 100);
//    console.log(`Progreso ${key}: ${porcentaje}%`);
//                    }
//                });

//                // Convertir resultado a dataURL.
//                return await new Promise((resolve, reject) => {
//                    const reader = new FileReader();
//                    reader.onloadend = () => resolve(reader.result);
//    reader.onerror = reject;
//    reader.readAsDataURL(resultadoBlob);
//                });

//            } catch (err) {
//        console.error('Error en la librería de eliminación de fondo:', err);
//    throw err;
//            }
//        };

//    console.log('Eliminación de fondo disponible');
//</script>