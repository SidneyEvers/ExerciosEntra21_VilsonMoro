function verificar(){

    const idade = document.querySelector(".idadecolocar").value;

    const tituidade = document.querySelector(".pidade");   

    const nomeatualizado = document.querySelector(".nomecolocar").value;

    if (nomeatualizado === '' || idade === '') {
        tituidade.innerText = 'Por favor, preencha todos os campos!';
        return false;
    }

    if(isNaN(idade)){
        tituidade.innerText = 'Por favor, digite apenas números no campo idade!'
        return false;
    }

    if(idade < 0){
      tituidade.innerText = 'Número inválido, digite novamente!';
      return false;
    }    

    if(idade < 18){
        tituidade.innerText = `${nomeatualizado} você é menor de idade`;
    }
    else{
        tituidade.innerText = `${nomeatualizado} você é maior de idade`;
    }

}
function resultadomedia() {
    const nota1 = document.querySelector(".n1").value;
    const nota2 = document.querySelector(".n2").value;
    const nota3 = document.querySelector(".n3").value;
    const frq = document.querySelector(".f1").value;
    const nomedentromedia = document.querySelector(".nomemedia").value;
    const titumedia = document.querySelector(".resultadomedia");

    if (nota1 === '' || nota2 === '' || nota3 === '' || frq === '' || nomedentromedia === '') {
        titumedia.innerText = 'Todos os campos precisam ser preenchidos!';
        return false;
    }

    if (isNaN(nota1) || isNaN(nota2) || isNaN(nota3) || isNaN(frq)) {
        titumedia.innerText = 'Apenas números podem ser digitados nos campos de notas e frequência!';
        return false;
    }

    const nota1Float = parseFloat(nota1);
    const nota2Float = parseFloat(nota2);
    const nota3Float = parseFloat(nota3);
    const frqFloat = parseFloat(frq);

    if (nota1Float < 0 || nota1Float > 10 || nota2Float < 0 || nota2Float > 10 || nota3Float < 0 || nota3Float > 10 || frqFloat < 0 || frqFloat > 100) {
        titumedia.innerText = 'Por favor, insira notas e frequência válidas (0 a 10 para notas e 0 a 100 para frequência)';
        return false;
    }

    const todasAsNotas = nota1Float + nota2Float + nota3Float;
    const mediaNotas = todasAsNotas / 3;

    if (mediaNotas >= 7 && frqFloat >= 75) {
        titumedia.innerText = `Média: ${mediaNotas.toFixed(2)} --> Aprovado`;
        console.log(mediaNotas);
    } else {
        titumedia.innerText = 'Você foi reprovado';
        console.log(mediaNotas);
    }
}
 
function calculoImcbase(){


    let idade = (document.querySelector(".idade1").value);

    let peso = (document.querySelector(".peso1").value);

    let altura = (document.querySelector(".altura1").value);

    let nomedentroimc = document.querySelector(".nomenoimc").value;

    var valormaximoimx = document.querySelector(".valortotalimc");

    if (idade === '' || peso === '' || altura === '' || nomedentroimc === '') {
        valormaximoimx.innerText = 'Por favor, preencha todos os campos.';
        return false;
    }

    if(isNaN(idade) || isNaN(peso) || isNaN(altura)){
        valormaximoimx.innerText = 'Apenas numeros podem ser digitados nos campos "idade, peso, altura!';
        return false;
    }

    idadeFloat = parseFloat(idade);
    pesoFloat = parseFloat(peso);
    alturaFloat = parseFloat(altura);

    var alturaoquadrado = parseFloat(alturaFloat*alturaFloat);

    var resultadoimc = parseFloat(pesoFloat / alturaoquadrado);

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

function verificarsalarionovo() {
    const basesalario = (document.querySelector(".salario1").value);
    const cargoprincipal = document.querySelector(".informecargo").value.toLowerCase();
    const resultadosalario = document.querySelector(".resultadosalario");
    const resultadoaumento = document.querySelector(".resultadoaumento");

    if (isNaN(basesalario) || basesalario === '') {
        resultadosalario.innerText = 'Por favor, insira um valor numérico no campo de salário.';
        resultadoaumento.innerText = '';
        return false;
    }

    if (cargoprincipal !== "gerente" && cargoprincipal !== "supervisor" && cargoprincipal !== "operador" && cargoprincipal !== "colaborador") {
        resultadosalario.innerText = 'Escolha uma opção de cargo válida!';
        resultadoaumento.innerText = '';
        return false;
    }

    const basesalariFloat = parseFloat(basesalario);

    let taxa;
    let aumentoPercentual;

    switch (cargoprincipal) {
        case "gerente":
            taxa = 5;
            aumentoPercentual = 5;
            break;
        case "supervisor":
            taxa = 8;
            aumentoPercentual = 8;
            break;
        case "operador":
            taxa = 9;
            aumentoPercentual = 9;
            break;
        default:
            taxa = 10;
            aumentoPercentual = 10;
    }

    const aumento = (basesalariFloat * taxa) / 100;
    const valorfinal = basesalariFloat + aumento;

    resultadosalario.innerText = `Seu aumento foi de ${aumentoPercentual}%!`;
    resultadoaumento.innerText = `Seu Salário final é de R$${valorfinal.toFixed(2)}`;
}

