function verificar(){
    const idade = document.querySelector(".idadecolocar").value;

    const tituidade = document.querySelector(".pidade");   

    if(idade < 18){
        tituidade.innerText = "Você é menor de idade";
    }
    else{
        tituidade.innerText = "Você é maior de idade";
    }
}

function resultadomedia(){

    let nota1 = parseFloat(document.querySelector(".n1").value);

    let nota2 = parseFloat(document.querySelector(".n2").value);

    let nota3 = parseFloat(document.querySelector(".n3").value);

    const frq = parseFloat(document.querySelector(".f1").value);

    const titumedia = document.querySelector(".resultadomedia");

    let todasAsNotas = parseFloat((nota1 + nota2 + nota3));

    let mediaNotas = parseFloat(todasAsNotas / 3);

    if(mediaNotas >= 7 && frq >= 75) {
        titumedia.innerText = `Media: ${mediaNotas} --> Aprovado`
        console.log(mediaNotas);
    } else {
        titumedia.innerText = 'Voce foi reprovado'
        console.log(mediaNotas)
    }
}

function calculoImcbase(){


    let idade = parseFloat(document.querySelector(".idade1").value);

    let peso = parseFloat(document.querySelector(".peso1").value);

    let altura = parseFloat(document.querySelector(".altura1").value);

    var alturaoquadrado = parseFloat(altura*altura);

    var resultadoimc = parseFloat(peso / alturaoquadrado);

    var valormaximoimx = document.querySelector(".valortotalimc");

   if(resultadoimc < 17){
    valormaximoimx.innerText = `Seu IMC é de ${resultadoimc}, você está muito abaixo do peso!`;
    console.log(resultadoimc);
   }

   else if(resultadoimc >= 17 && resultadoimc <= 18.49){
    valormaximoimx.innerText = `Seu IMC é de ${resultadoimc.toFixed(2)}, você está abaixo do peso!`;
    console.log(resultadoimc);
   }

   else if(resultadoimc >= 18.5 && resultadoimc <= 24.99){
    valormaximoimx.innerText = `Seu IMC é de ${resultadoimc.toFixed(2)}, você está com peso normal!`;
   }

   else if(resultadoimc >= 25 && resultadoimc <= 29.99){
    valormaximoimx.innerText = `Seu IMC é de ${resultadoimc.toFixed(2)}, você está acima do peso!`;
   }

   else if(resultadoimc >= 30 && resultadoimc <= 34.99){
    valormaximoimx.innerText = `Seu IMC é de ${resultadoimc.toFixed(2)}, você está com obesidade 1!`;
   }

   else if(resultadoimc >= 35 && resultadoimc <= 39.99){
    valormaximoimx.innerText = `Seu IMC é de ${resultadoimc.toFixed(2)}, você está com obesidade 2!`;
   }

   else{
    valormaximoimx.innerText = `Seu IMC é de ${resultadoimc.toFixed(2)}, você está com obesidade 3!`;
   }
}


