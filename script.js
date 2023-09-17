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
        let nota1 = parseFloat(document.querySelector(".n1").value);
        let nota2 = parseFloat(document.querySelector(".n2").value);
        let nota3 = parseFloat(document.querySelector(".n3").value);
        const frq = parseFloat(document.querySelector(".f1").value);
        let nomedentromedia = document.querySelector(".nomemedia").value;
        const titumedia = document.querySelector(".resultadomedia");
    
        
        if (nomedentromedia === '') {
            titumedia.innerText = 'Todos os campos precisam ser preenchidos!';
            return false;
        }
    
        
        if (isNaN(nota1) || isNaN(nota2) || isNaN(nota3) || isNaN(frq)) {
            titumedia.innerText = 'Por favor, digite apenas números válidos nas notas ou frequência!';
            return false;
        }
    
        
        if (nota1 < 0 || nota1 > 10 || nota2 < 0 || nota2 > 10 || nota3 < 0 || nota3 > 10 || frq < 0 || frq > 100) {
            titumedia.innerText = 'Por favor, insira notas e frequência válidas (0 a 10 para notas e 0 a 100 para frequência)';
            return false;
        }
    
        let todasAsNotas = nota1 + nota2 + nota3;
        let mediaNotas = todasAsNotas / 3;
    
        if (mediaNotas >= 7 && frq >= 75) {
            titumedia.innerText = `Média: ${mediaNotas.toFixed(2)} --> Aprovado`;
            console.log(mediaNotas);
        } else {
            titumedia.innerText = 'Você foi reprovado';
            console.log(mediaNotas);
        }
    }
    
function calculoImcbase(){


    let idade = parseFloat(document.querySelector(".idade1").value);

    let peso = parseFloat(document.querySelector(".peso1").value);

    let altura = parseFloat(document.querySelector(".altura1").value);

    let nomedentroimc = document.querySelector(".nomenoimc").value;

    var alturaoquadrado = parseFloat(altura*altura);

    var resultadoimc = parseFloat(peso / alturaoquadrado);

    var valormaximoimx = document.querySelector(".valortotalimc");

    if (isNaN(idade) || isNaN(peso) || isNaN(altura) || nomedentroimc === '') {
        valormaximoimx.innerText = 'Por favor, preencha todos os campos.';
        return;
    }

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

function verificarsalarionovo(){

    let salariobase = parseFloat(document.querySelector(".salario1").value);

    let cargoprincipal = document.querySelector(".informecargo").value.toLowerCase();

    let valormaximosalario = parseFloat(document.querySelector(".resultadosalario").value);

    let valortotalaumento = parseFloat(document.querySelector(".resultadoaumento").value);


    if(isNaN(salariobase) || cargoprincipal === ''){
        document.querySelector(".resultadosalario").innerText = 'Todos os campos precisam ser preenchidos!';
        document.querySelector(".resultadoaumento").innerText = '';
        return false;
    }
    
    if (cargoprincipal !== "gerente" && cargoprincipal !== "supervisor" && cargoprincipal !== "operador" && cargoprincipal !== "colaborador") {
        document.querySelector(".resultadosalario").innerText = 'Escolha uma opção de cargo válida!';
        document.querySelector(".resultadoaumento").innerText = '';
    return false;
    }
   
    

    if(cargoprincipal == "gerente"){

        let taxa1 = salariobase / 100 * 5;

        let valorfinal = salariobase + taxa1;

        document.querySelector(".resultadosalario").innerText = "Seu aumento foi de 5%!";

        document.querySelector(".resultadoaumento").innerText = `Seu Salário final é de R$${valorfinal}`;
    }
    else if(cargoprincipal == "supervisor"){

        let taxa2 = salariobase / 100 * 8;

        let valorfinal = salariobase + taxa2;

        document.querySelector(".resultadosalario").innerText = "Seu aumento foi de 8%!";

        document.querySelector(".resultadoaumento").innerText = `Seu Salário final é de R$${valorfinal}`;
    }
    else if(cargoprincipal == "operador"){

        let taxa3 = salariobase / 100 * 9;

        let valorfinal = salariobase + taxa3;

        document.querySelector(".resultadosalario").innerText = "Seu aumento foi de 9%!";

        document.querySelector(".resultadoaumento").innerText = `Seu Salário final é de R$${valorfinal}`;
    }
    else{
        let taxa4 = salariobase / 100 * 10;

        let valorfinal = salariobase + taxa4;

        document.querySelector(".resultadosalario").innerText = "Seu aumento foi de 10%!";

        document.querySelector(".resultadoaumento").innerText = `Seu Salário final é de R$${valorfinal}`;
    }
}

