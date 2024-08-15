Informações Importantes:
1. Existem documentações criadas pelo Draw.io na pasta documentacao para entender um pouco mais sobre a funcionalidade relatório e a arquitetura do sistema.
2. O CRUD é realizado pelo EF e algumas consultas que quero focar no desempenho e no total controle utilizo o dapper (Consulta para obter o relatório por exemplo)
   
Passo a Passo para testar o aplicativo
1. Vá para a pasta onde está localizado o arquivo docker-compose e abra o cmd e digite docker-compose build, após finalizado o processo digite docker-compose up e aguarde, o RelatorioJob dará uns erros é normal porque ele vai tentar se conectar com o rabbimq e ele não vai ter se inicializado completamente(Optei por fazer a resiliencia de conexão no docker-compose ao invés de colocar no código) então ele ficará tentando conectar até o rabbitMQ se inicializar por completo
2. Após finalizado o comando docker-compose up e no relatorioJob apareceu consumer started for queue  entre no swagger http://localhost:8080/swagger/index.html
3. Crie Projeto no Endpoint Post Projeto, você pode optar por já criar ele adicionando tarefas ou ir depois no endpoint Post Tarefas para adicionar as tarefas separadamente
4. Você pode editar a tarefa no endpoint Put Tarefas para alterar propriedades da tarefa status = 0 PENDENTE, em Andamento = 1, Concluido 2. Caso queira adicionar comentários na tarefa tem o endpoint Tarefas/Comentario Post, toda vez que você edita uma tarefa eu pego um id aleátorio de analista por meio de um serviço mockado que eu criei isso é importante para saber quem finalizou aquela tarefa!
5. Você pode visualizar o histórico de alterações no endpoint Get Projetos
6. Para gerar o relátorio é necessário ter o ID do Gerente pois a rota só é permitida para gerentes e do Analista que você quer ter o reltório, você consegue obter esses Ids nas rotas Get Analistas e Get Gerentes,
7. Com os Ids necessários em mãos vá na rota Post Relatorio "GERAR", essa rota vai validar se os ids são válidos e enviar uma mensagem para a fila que será consumida pelo job relatório.
8. Após isso, vá com os ids de analista e gerente na rota de Get Relatorio Obter e ela retornara os resultados do relatório de tarefas concluidas daquele analista que você colocou.

Fase 2 Refinamento:
1. Hoje o relatório é feito somente dos 30 dias anteriores, seria interessante o Gerente definir quantos dias anteriores o relatório iria pegar no momento da requisição?
2. A quantidade máxima de tarefas hoje é 20. Seria interessante na hora do cadastro do projeto definir o limite de tarefas com isso não ficariamos engessados somente em 20?
3. Sobre o relatório você acredita que ele será uma operação que será acessada por muitos usuarios e ela será uma consulta custosa? Estou perguntando isso pois talvez não tenho certeza se há necessidade de adicionar um processo assincrono utilizando filas para melhorar o desempenho/escalabilidade e consequentemente adicionar a complexidade que vem junto com essas tecnologias.

Fase 3 Final:
1. Caso seja uma aplicação de grande porte utilizado por muitos usuarios simultaneamente na visão de Cloud eu adicionaria no EKS para fazer a orquestração dos containers e sua escabilidade de forma mais fácil
2. Caso não seja uma aplicação que precise tanto de escalabilidade eu manteria em um EC2 rodando esse docker-compose e definiria a memoria para cada container.
3. Desenvolveria um pipeline CI/CD para branch master e develop, toda vez que viesse um commit para essas branchs iniciaria um pipeline que rodaria os testes para ver se todos passaram, rodaria o sonar para ver se não tem codesmells e ter uma quantidade mínima de coverage, e enviaria um sinal para o ec2 fazer todo o processo de build e deploy do docker-compose.
4. Em caso de Subida com problema eu deixaria salvo a ultima imagem do docker-compose criada antes da ultima atualização para poder dar rollback.
5. Adicionaria também um sistema de aprovação de pull request para a branch master onde outros desenvolvedores terão que avaliar o código e aprovar.
