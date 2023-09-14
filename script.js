function verificar(){
    const idade = document.querySelector(".idade").value;

    const titulo = document.querySelector(".titulidade");   

    if(idade < 18){
        titulo.innerText = "Você é menor de idade";
    }
    else{
        titulo.innerText = "Você é maior de idade";
    }
}