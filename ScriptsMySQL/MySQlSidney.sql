create database sidneydb;

create table tb_contatos(
id int auto_increment,
nome varchar(45), 
email varchar(45),
telefone varchar(14),
primary key(id)
);

create table tb_locais(
id int auto_increment,
nome varchar(45),
rua varchar(45),
numero int,
primary key(id)
);

create table tb_compromissos(
id int auto_increment,
descricao varchar(45),
data date,
hora time,
primary key(id)
);

create table compromissos_has_contatos(
tb_locais_id int,
tb_contatos_id int 
);


alter table tb_compromissos add column tb_locais_id int;
alter table tb_compromissos add constraint fk_locais foreign key(tb_locais_id) references tb_locais(id);


alter table compromissos_has_contatos add constraint fk_test foreign key(tb_locais_id) references tb_locais(id);
alter table compromissos_has_contatos add constraint fk_test2 foreign key(tb_contatos_id) references tb_contatos(id);

alter table compromissos_has_contatos add column tb_compromissos_id int;

alter table compromissos_has_contatos add constraint fk_compromissos foreign key(tb_compromissos_id) references tb_compromissos(id);





alter table tb_compromissos drop constraint fk_locais_id;
 
alter table tb_compromissos add column tb_contatos_id int;
alter table tb_compromissos add constraint fk_contatos foreign key(tb_contatos_id) references tb_contatos(id);

alter table tb_compromissos add column tb_locais_id int;
alter table tb_compromissos add constraint fk_locais_id foreign key(tb_locais_id) references tb_locais(id);

insert into tb_contatos(nome, email, telefone) values('Sidney','sidney@email.com','(47)9999-9999');

insert into tb_contatos(nome, email, telefone) values('Jessica','jessica@email.com','(47)8888-8888');

insert into tb_locais(nome, rua, numero) values('Tarumã office','Rua XV de novembro','1585');

insert into tb_locais(nome, rua, numero) values('Shopping', 'Rua 7 de setembro', '3000');

insert into tb_compromissos(descricao, data, hora, tb_contatos_id, tb_locais_id) values('Aula proway c#','2028-10-25','19:00:00',2,1);

insert into tb_compromissos(descricao, data, hora, tb_contatos_id, tb_locais_id) values('Reunião Equipe','2028-05-30','10:00:00',2,3);

select * from tb_compromissos;

select * from tb_locais;

select * from tb_contatos;

delete from tb_compromissos where id = 10;

select descricao, data, hora, tb_contatos.nome, telefone, rua, numero from tb_compromissos, tb_contatos, tb_locais where tb_compromissos.tb_contatos_id = tb_contatos.id and tb_compromissos.tb_locais_id = tb_locais.id;

select c.descricao, c.data, c.hora, a.nome, a.telefone, b.nome, b.rua 
from tb_compromissos c 
inner join tb_contatos a on c.tb_contatos_id = a.id 
inner join tb_locais b on c.tb_locais_id = b.id
where c.id = 9;

select a.descricao, a.data, a.hora, b.nome, b.email, c.nome, c.rua
from tb_compromissos a
inner join tb_contatos b on a.tb_contatos_id = b.id
inner join tb_locais c on a.tb_locais_id = c.id
where c.id = 3;
