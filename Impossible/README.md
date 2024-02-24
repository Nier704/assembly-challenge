Crie um projecto de raiz

O que é esperado
	que o software armazene os dados em ficheiro(s)
	que seja possivel realizar os métodos de 'CRUD' E outros métodos para uso do software
		ex: um software de venda de produtos é possível realizar os métodos de CRUD
		    e há de existir mais métodos, em outra camada de serviço, que façam a venda dos mesmos.
	que tenha regras de negócio condizentes com o objeto escolhido,
		ex: um objeto produto até pode ser criado com valor de venda 0 mas o processo de venda não pode ser concluído por não ter preço

Observações / Sugestões:
Use a arquitectura SOA uma vez que há uma cábula nos exercícios mais fáceis.
Para o armazenamento em ficheiro é preciso ser capaz de criar, editar e apagar ficheiros do sistema operativo. [https://www.w3schools.com/cs/cs_files.php]
Para armazenar o objecto em ficheiro utilize a abordagem em JSON. [https://www.w3schools.com/js/js_json_intro.asp]
Para fazer o 'Parse' de JSON<>Object use o objeto JsonSerializer. [https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-8-0]