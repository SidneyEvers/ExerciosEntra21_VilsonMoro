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

create table tb_produtos_vendas(
valor_unitario varchar(10),
quantidade int
);

create table tb_compras_produtos(
tb_compras_id int,
tb_produtos_id int
);

alter table tb_compras_produtos add column tb_compras_id int,
alter table tb_compras_produtos add constraint fk_compras foreign key(tb_compras_id) references tb_compras(id),

alter table tb_compras_produtos add column tb_produtos_id int,
alter table tb_compras_produtos add constraint fk_produtos1 foreign key(tb_produtos_id) references tb_produtos(id),

alter table tb_produtos_vendas add column tb_produtos_id int,
alter table tb_produtos_vendas add constraint fk_produtos foreign key(tb_produtos_id) references tb_produtos(id),

alter table tb_produtos_vendas add column tb_vendas_id int,
alter table tb_produtos_vendas add constraint fk_vendas foreign key(tb_vendas_id) references tb_vendas(id),

alter table tb_produtos add column tb_categoria_id int,
alter table tb_produtos add constraint fk_categoria foreign key(tb_categoria_id) references tb_categoria(id),

alter table tb_produtos add column tb_fornecedor_id int,
alter table tb_produtos add constraint fk_fornecedor1 foreign key(tb_fornecedor_id) references tb_fornecedor(id),

alter table tb_compras add column tb_fornecedor_id int, 
alter table tb_compras add constraint fk_fornecedor foreign key(tb_fornecedor_id) references tb_fornecedor(id),

alter table tb_vendas add column tb_clientes_id int, 
alter table tb_vendas add constraint fk_clientes foreign key(tb_clientes_id) references tb_clientes(id),



create table tb_valor_a_receber(
id int auto_increment,
valor varchar(45),
data_de_vencimento varchar(45),
parcelas int, 
valor_parcela varchar(45),
primary key(id)
);

alter table tb_valor_a_receber add column tb_clientes_id int,
alter table tb_valor_a_receber add constraint fk_clientes1 foreign key(tb_clientes_id) references tb_clientes(id),

create table tb_contas_a_pagar(
id int auto_increment,
nome_duplicata varchar(45),
valor varchar(45),
parcelas int, 
data_vencimento date,
primary key(id)
);

alter table tb_contas_a_pagar add column tb_fornecedor_id int,
alter table tb_contas_a_pagar add constraint fk_fornecedor_contas foreign key(tb_fornecedor_id) references tb_fornecedor(id),

alter table tb_valor_a_receber add column tb_vendas_id int,
alter table tb_valor_a_receber add constraint fk_vendas1 foreign key(tb_vendas_id) references tb_vendas(id)







