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
alter table tb_valor_a_receber add constraint fk_vendas1 foreign key(tb_vendas_id) references tb_vendas(id),

alter table tb_produtos add column quantidade int,

alter table tb_compras add column quantidade int,

alter table tb_vendas add column quantidade int,

alter table tb_valor_a_receber drop column tb_clientes_id,

alter table tb_contas_a_pagar add column tb_compras_id int,
alter table tb_contas_a_pagar add constraint fk_compras_pagar foreign key(tb_compras_id) references tb_compras(id),

alter table tb_contas_a_pagar drop column tb_fornecedor_id,

alter table tb_produtos add column valor varchar(45)

select * from tb_clientes;

insert into tb_clientes(nome, email, telefone) 
values('Sidney','sidney@email.com','9999-9999');

insert into tb_clientes(nome, email, telefone) 
values('Jessica','jessica@email.com','8888-8888');

select * from tb_fornecedor;

insert into tb_fornecedor(nome, empresa, email)
values('Breno','Calçados ABC','breno@abcemail.com')

insert into tb_fornecedor(nome, empresa, email)
values('Pedro','Camisas ZYP','pedro@zypemail.com');

select * from tb_categoria;

select * from tb_fornecedor;

delete from tb_categoria where id > 3

insert into tb_categoria(nome_categoria)
values('Calçados'),('Camisas'),('Calças');

select * from tb_produtos;

insert into tb_produtos(nome_produto, tb_categoria_id, tb_fornecedor_id, quantidade, valor)
values('Camisa ADIDAS','2','2', 20, 100.00)

insert into tb_produtos(nome_produto, tb_categoria_id, tb_fornecedor_id, quantidade, valor)
values('Tenis Nike',1, 1, 15, 200.00);

select a.id, a.nome_produto, b.nome_categoria, c.nome, a.quantidade, a.valor
from tb_produtos a 
inner join tb_categoria b on a.tb_categoria_id = b.id
inner join tb_fornecedor c on a.tb_fornecedor_id = c.id

select * from tb_vendas;

select * from tb_produtos_vendas;

insert into tb_vendas(data_venda, tb_clientes_id, quantidade)
values('2023-10-25', 2, 3);

insert into tb_vendas(data_venda, tb_clientes_id, quantidade)
values('2022-02-19',1,2)

insert into tb_produtos_vendas(valor_unitario, quantidade, tb_produtos_id, tb_vendas_id)
values('30','2','2','1');

insert into tb_produtos_vendas(valor_unitario, quantidade, tb_produtos_id, tb_vendas_id)
values('15',10,1,2)

select a.valor_unitario, a.quantidade, b.nome_produto, c.data_venda
from tb_produtos_vendas a 
inner join tb_produtos b on a.tb_produtos_id = b.id
inner join tb_vendas c on a.tb_vendas_id = c.id

select * from tb_compras;

insert into tb_compras(data_compra, tb_fornecedor_id, quantidade)
values('2020-05-20','2','50')

select * from tb_compras_produtos;

insert into tb_compras_produtos(tb_compras_id, tb_produtos_id, quantidade)
values('1','2',10);

select a.id, a.nome_produto, b.nome_categoria, c.nome, quantidade, valor
from tb_produtos a 
inner join tb_categoria b on a.tb_categoria_id = b.id
inner join tb_fornecedor c on a.tb_fornecedor_id = c.id


select * from tb_valor_a_receber;

insert into tb_valor_a_receber(valor, data_de_vencimento, parcelas, valor_parcela, tb_vendas_id)
values('60.00','2023-11-14','2','30.00','1')


























