create database sidneyLoja;

create table tb_compras(
id int auto_increment,
data_compra date,
primary key(id)
);

create table tb_vendas(
id int auto_increment,
data_venda date,
primary key(id)
);

create table tb_clientes(
id int auto_increment,
nome varchar(45),
email varchar(45),
telefone varchar(45),
primary key(id)
);

create table tb_produtos(
id int auto_increment,
nome_produto varchar(45),
primary key(id)
);

create table tb_categoria(
id int auto_increment,
nome_categoria varchar(45),
primary key(id)
);

create table tb_fornecedor(
id int auto_increment,
nome varchar(45),
empresa varchar(45),
email varchar(45),
primary key(id)
);
