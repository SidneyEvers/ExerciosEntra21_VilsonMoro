function verificar(){
    const idade = document.querySelector(".idade").value;

    const titulo = document.querySelector(".titulidade");

    


    if(idade < 18){
        alert()
    }
    else{
        titulo.innerText = "Você é maior de idade";
    }
}