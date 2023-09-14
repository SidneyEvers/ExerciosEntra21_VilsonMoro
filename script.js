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

function resultadomedia(){

    let nota1 = parseFloat(document.querySelector(".n1").value);

    let nota2 = parseFloat(document.querySelector(".n2").value);

    let nota3 = parseFloat(document.querySelector(".n3").value);

    const frq = parseFloat(document.querySelector(".f1").value);

    const titumedia = document.querySelector(".resultadomedia");

    let todasAsNotas = parseInt((nota1 + nota2 + nota3));

    let mediaNotas = parseInt(todasAsNotas / 3);

    if(mediaNotas >= 7 && frq >= 75) {
        titumedia.innerText = `Media: ${mediaNotas} --> Aprovado`
        console.log(mediaNotas);
    } else {
        titumedia.innerText = 'Voce foi reprovado'
        console.log(mediaNotas)
    }
}