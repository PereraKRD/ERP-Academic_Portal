// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}

function saveAsFile(fileName, bytesBase64) {
    var link = document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Necessary for Firefox
    link.click();
    document.body.removeChild(link);
}
