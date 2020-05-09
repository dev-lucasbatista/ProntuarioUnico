$.ajaxSetup({
    type: 'post',
    dataType: 'json',
    cache: false,
    error: function (XMLHttpRequest, textStatus, errorThrown) { //Catch
        if (XMLHttpRequest.status == 403 || (XMLHttpRequest.responseText.indexOf('<html>') >= 0 && XMLHttpRequest.responseText.indexOf('<title>') <= 0)) {
            if (window.msgExibir) {
                msgExibir(XMLHttpRequest.status + ' - ' + XMLHttpRequest.statusText);
            } else {
                alert(XMLHttpRequest.status + ' - ' + XMLHttpRequest.statusText);
            }
        } else {
            if (window.Loading) {
                Loading(false);
            }
            if (window.msgExibir) {
                msgExibir(errorThrown + '\n\n' + $(XMLHttpRequest.responseText).filter('title').get(0).innerText);
            } else {
                alert(errorThrown + '\n\n' + $(XMLHttpRequest.responseText).filter('title').get(0).innerText);
            }
        }
    },
    beforeSend: function (xhr) {
        var lobjToken = $('input[name=__RequestVerificationToken]').val();
        xhr.setRequestHeader('__RequestVerificationToken', lobjToken);
        if (window.Loading) {
            Loading(true);
        }
    },
    complete: function (xhr, textStatus) {
        if (window.Loading) {
            Loading(false);
        }
    }
});

Date.prototype.toJSON = function () {
    return this.getFullYear() + "/" + ((this.getMonth() + 1) < 10 ? '0' + (this.getMonth() + 1) : (this.getMonth() + 1)) + "/" + this.getDate() + " " + (this.getHours() < 10 ? '0' + this.getHours() : this.getHours()) + ":" + (this.getMinutes() < 10 ? '0' + this.getMinutes() : this.getMinutes()) + ':' + (this.getSeconds() < 10 ? '0' + this.getSeconds() : this.getSeconds());
};

Number.prototype.round = function (places) {
    return +(Math.round(this + "e+" + places) + "e-" + places);
}

if (!String.prototype.startsWith) {
    String.prototype.startsWith = function (prefix) {
        return this.indexOf(prefix) === 0;
    }
}

if (!String.prototype.endsWith) {
    String.prototype.endsWith = function (searchString, position) {
        var subjectString = this.toString();
        if (typeof position !== 'number' || !isFinite(position) || Math.floor(position) !== position || position > subjectString.length) {
            position = subjectString.length;
        }
        position -= searchString.length;
        var lastIndex = subjectString.indexOf(searchString, position);
        return lastIndex !== -1 && lastIndex === position;
    };
}

if (!String.prototype.padLeft) {
    String.prototype.padLeft = function (l, c) { return Array(l - this.length + 1).join(c || ' ') + this }
}

if (!String.prototype.padRight) {
    String.prototype.padRight = function (l, c) { return this + Array(l - this.length + 1).join(c || ' ') }
}

// Warn if overriding existing method
if (Array.prototype.equals) {
    console.warn("Overriding existing Array.prototype.equals. Possible causes: New API defines the method, there's a framework conflict or you've got double inclusions in your code.");
}
// attach the .equals method to Array's prototype to call it on any array
Array.prototype.equals = function (array) {
    // if the other array is a falsy value, return
    if (!array)
        return false;

    // compare lengths - can save a lot of time 
    if (this.length != array.length)
        return false;

    for (var i = 0, l = this.length; i < l; i++) {
        // Check if we have nested arrays
        if (this[i] instanceof Array && array[i] instanceof Array) {
            // recurse into the nested arrays
            if (!this[i].equals(array[i]))
                return false;
        }
        else if (this[i] != array[i]) {
            // Warning - two different object instances will never be equal: {x:20} != {x:20}
            return false;
        }
    }
    return true;
}
// Hide method from for-in loops
Object.defineProperty(Array.prototype, "equals", { enumerable: false });


function FormataDataStr(vobjValue, vblnHora, vblnMinuto, vblnSegundo) {
    var lstrData = new String('');

    try {
        vblnMinuto = Nvl(vblnMinuto, Nvl(vblnHora, true));
        vblnSegundo = Nvl(vblnSegundo, Nvl(vblnHora, true));

        if (vobjValue != null && vobjValue != undefined) {
            if (typeof (vobjValue) == 'string') {
                vobjValue = new Date(vobjValue);
            }
            lstrData = (vobjValue.getDate() < 10 ? '0' + vobjValue.getDate() : vobjValue.getDate());
            lstrData = lstrData + '/' + ((vobjValue.getMonth() + 1) < 10 ? '0' + (vobjValue.getMonth() + 1) : (vobjValue.getMonth() + 1));
            lstrData = lstrData + '/' + (vobjValue.getFullYear());
            if (vblnHora == null || vblnHora == undefined || vblnHora == true) {
                lstrData = lstrData + ' ' + (vobjValue.getHours() < 10 ? '0' + vobjValue.getHours() : vobjValue.getHours());
            }
            if (vblnMinuto == null || vblnMinuto == undefined || vblnMinuto == true) {
                lstrData = lstrData + ':' + (vobjValue.getMinutes() < 10 ? '0' + vobjValue.getMinutes() : vobjValue.getMinutes());
            }
            if (vblnSegundo == null || vblnSegundo == undefined || vblnSegundo == true) {
                lstrData = lstrData + ':' + (vobjValue.getSeconds() < 10 ? '0' + vobjValue.getSeconds() : vobjValue.getSeconds());
            }
        }

        return lstrData;
    } catch (ex) {
        throw ex;
    }
}

function Agora(vstrTipo) {
    try {
        var ldatAgora = new Date();

        if (Nvl(vstrTipo, 'F') == 'I') {
            ldatAgora.setHours(0);
            ldatAgora.setMinutes(0);
            ldatAgora.setSeconds(0);
            ldatAgora.setMilliseconds(0);
        } else if (vstrTipo == 'F') {
            ldatAgora.setHours(23);
            ldatAgora.setMinutes(59);
            ldatAgora.setSeconds(59);
            ldatAgora.setMilliseconds(0);
        }

        return ldatAgora;
    } catch (ex) {
        throw ex;
    }
}

function getGlobalPath() {
    var lobjLocation = new Object();
    var lstrGlobalPath = new String();
    var larrPath = new Array();
    try {
        lobjLocation = window.location;
        larrPath = lobjLocation.pathname.split('/');
        lstrGlobalPath = lobjLocation.protocol + '//' + lobjLocation.host;
        return lstrGlobalPath;
    } catch (ex) {
        throw ex;
    }
}

function getFullGlobalPath() {
    var lobjLocation = new Object();
    var lstrGlobalPath = new String();
    var larrPath = new Array();
    try {
        lobjLocation = window.location;
        larrPath = lobjLocation.pathname.split('/');
        lstrGlobalPath = lobjLocation.protocol + '//' + lobjLocation.host + '/' + larrPath[1] + '/' + larrPath[2];
        return lstrGlobalPath;
    } catch (ex) {
        throw ex;
    }
}

function Nvl(vobjValor, vobjValorSeNulo) {
    var lobjRetorno;
    if (vobjValor == null || vobjValor == undefined) {
        lobjRetorno = vobjValorSeNulo;
    } else {
        lobjRetorno = vobjValor;
    }

    return lobjRetorno;
}

function LoadScript(vstrNome, vstrGolbalPath) {
    var lobjScript = new Object();
    try {
        lobjScript = document.createElement('script');
        lobjScript.type = 'text/javascript';
        lobjScript.src = vstrGolbalPath + vstrNome + '?' + FormataDataStr(Agora(), true).replace(' ', '').split('/').join('').split(':').join('');

        document.head.appendChild(lobjScript);
    } catch (ex) {
        throw ex;
    }
}

function LoadCss(vstrNome, vstrGolbalPath) {
    var lobjScript = new Object();
    try {
        lobjCss = document.createElement('link');
        lobjCss.type = 'text/css';
        lobjCss.rel = 'stylesheet';
        lobjCss.href = vstrGolbalPath + vstrNome + '?' + FormataDataStr(Agora(), true).replace(' ', '').split('/').join('').split(':').join('');
        document.head.appendChild(lobjCss);
    } catch (ex) {
        throw ex;
    }
}

function Redirecionar(vobjEvent, vstrUrl) {
    var lstrReturnURL = new String('');
    try {
        if (vobjEvent == null) {
            lstrReturnURL = vstrUrl;
        }

        if (lstrReturnURL.length > 0) {
            location.href = gstrGlobalPath + lstrReturnURL;
        }
    } catch (ex) {
        msgExibir(ex);
    }
}

$(window).on('load', function () {
    //Altera o cursor do body para o default
    document.body.style.cursor = 'auto';
    //Visualiza o conteúdo da tela
    document.querySelector('[load]').style.display = '';
    document.querySelector('[load]').removeAttribute('load');
});