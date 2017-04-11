using ProjetoViagens.Data;
using ProjetoViagens.DB.Base;
using ProjetoViagens.Model;
using ProjetoViagens.Model.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoViagens
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoMenuPrincipal = "";

            do
            {
                opcaoMenuPrincipal = MenuPrincipal();
                if (opcaoMenuPrincipal == "1")
                {
                    string opcaoMenuCadastro = MenuCadastro();
                    if (opcaoMenuCadastro == "1")
                    {
                        //CADASTRAR PLANETA
                        CadastarPlaneta();
                    }
                    else if (opcaoMenuCadastro == "2")
                    {
                        //CADASTRAR CLIENTE
                        CadastrarCliente();
                    }
                    else if (opcaoMenuCadastro == "3")
                    {
                        //CADASTRAR TRANSPORTE

                    }
                    else if (opcaoMenuCadastro == "4")
                    {
                        //CADASTRAR VIAGEM

                    }
                }
                else if (opcaoMenuPrincipal == "2")
                {
                    string opcaoMenuConsulta = MenuConsulta();
                    if (opcaoMenuConsulta == "1")
                    {
                        //CONSULTAR PLANETA
                        MenuConsultaOpcao("Planeta");
                    }
                    else if (opcaoMenuConsulta == "2")
                    {
                        //CONSULTAR CLIENTE
                        MenuConsultaOpcao("Cliente");
                    }
                    else if (opcaoMenuConsulta == "3")
                    {
                        //CONSULTAR TRANSPORTE
                    }
                    else if (opcaoMenuConsulta == "4")
                    {
                        //CONSULTAR VIAGEM DISPONIVEIS
                        MenuConsultaOpcao("viagem"); 
                    }
                }
                else if (opcaoMenuPrincipal == "3")
                {
                    string opcaoMenuConsulta = MenuAtualizar();
                    if (opcaoMenuConsulta == "1")
                    {
                        //ATUALIZAR PLANETA
                        AtualizaPlaneta();
                    }
                    else if (opcaoMenuConsulta == "2")
                    {
                        //ATUALIZAR CLIENTE
                        AtualizaCliente();
                    }
                    else if (opcaoMenuConsulta == "3")
                    {
                        //ATUALIZAR TRANSPORTE
                    }
                    else if (opcaoMenuConsulta == "4")
                    {
                        //ATUALIZAR VIAGEM DISPONIVEIS
                    }
                }
                else if (opcaoMenuPrincipal == "4")
                {
                    string opcaoMenuConsulta = MenuExcluir();
                    if (opcaoMenuConsulta == "1")
                    {
                        //EXCLUIR PLANETA
                        ExcluiPlaneta();
                    }
                    else if (opcaoMenuConsulta == "2")
                    {
                        //EXCLUIR CLIENTE
                        
                    }
                    else if (opcaoMenuConsulta == "3")
                    {
                        //EXCLUIR TRANSPORTE
                    }
                    else if (opcaoMenuConsulta == "4")
                    {
                        //EXCLUIR VIAGEM
                    }
                }
                else if (opcaoMenuPrincipal == "5")
                {
                    //BOOKING DA VIAGEM
                    string opcaoMenuBooking = MenuBooking();
                    if (opcaoMenuBooking == "1")
                    {
                        //FAZER BOOKING
                        ViagemCliente viagemCliente = new ViagemCliente();
                        Console.WriteLine("Informe o ID do Cliente:");
                        viagemCliente.IdCliente = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("#################################### VIAGENS DISPONÍVEIS ###################################");
                        Console.WriteLine("############################################################################################");
                        ConsultaTodasViagensDisponiveis();
                        Console.WriteLine("############################################################################################");
                        Console.WriteLine("");

                        Console.WriteLine("Informe o ID da Viagem Disponível:");
                        viagemCliente.IdViagemDispo = Convert.ToInt32(Console.ReadLine());
                        Console.ReadKey();
                    }
                    else if (opcaoMenuBooking == "2")
                    {
                        //CONSULTAR BOOKING

                    }
                    else if (opcaoMenuBooking == "3")
                    {
                        //ATUALIZAR BOOKING
                    }
                    else if (opcaoMenuBooking == "4")
                    {
                        //EXCLUIR BOOKING
                    }
                }
            } while (opcaoMenuPrincipal.ToLower() != "x");

        }

        private static string MenuBooking()
        {
            Header();
            Console.WriteLine("Menu 5 - Booking da Viagem");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Fazer Booking");
            Console.WriteLine("2 - Consultar Booking");
            Console.WriteLine("3 - Atualizar Booking");
            Console.WriteLine("4 - Excluir Booking");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }

        private static void ExcluiPlaneta()
        {
            Console.WriteLine("Informe o ID do Planeta para excluir:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tem certeza que deseja excluir? (s/n)");
            string opcaoCerteza = Console.ReadLine();

            if (opcaoCerteza.Equals("s"))
            {
                PlanetaRepository repoPlaneta = new PlanetaRepository();
                repoPlaneta.Excluir(id, "planetas_del");
            }
            else
            {
                Console.WriteLine("Planeta NÂO foi excluido!");
                Console.WriteLine("");
            }

            Console.ReadKey();
        }

        #region AtualizarPlaneta
        private static void AtualizaPlaneta()
        {
            string encerrar = "";
            do
            {
                PlanetaRepository repoPlaneta = new PlanetaRepository();

                Console.WriteLine("");
                Console.WriteLine("Informe o nome do Planeta para atualizar:");
                string nome = Console.ReadLine();

                MostraConsultaPlanetaPorNome(nome);

                Console.WriteLine("Tem certeza que deseja atualizar? (s/n)");
                string opcaoCerteza = Console.ReadLine();

                if (opcaoCerteza.Equals("s"))
                {
                    Planetas planeta = PerguntasPadraoPlaneta();
                    repoPlaneta.Atualizar(planeta, "planetas_upd");
                }
                else
                {
                    Console.WriteLine("Deseja sair? (s/n)");
                    encerrar = Console.ReadLine();
                }

            } while (encerrar != "s");
        }
        #endregion

        #region AtualizaCliente
        private static void AtualizaCliente()
        {
            string encerrar = "";
            do
            {
                ClienteRepository repoCliente = new ClienteRepository();

                Console.WriteLine("");
                Console.WriteLine("Informe o nome do Cliente para atualizar:");
                string nome = Console.ReadLine();

                MostraConsultaClientePorNome(nome);

                Console.WriteLine("Tem certeza que deseja atualizar? (s/n)");
                string opcaoCerteza = Console.ReadLine();

                if (opcaoCerteza.Equals("s"))
                {
                    Clientes cliente = PerguntasPadraoCliente();
                    repoCliente.Atualizar(cliente, "clientes_upd");
                }
                else
                {
                    Console.WriteLine("Deseja sair? (s/n)");
                    encerrar = Console.ReadLine();
                }

            } while (encerrar != "s");
        } 
        #endregion

        #region CadastrarCliente
        private static void CadastrarCliente()
        {
            ClienteRepository repoCliente = new ClienteRepository();

            Console.WriteLine("Menu 1-2 - Cadastrar Cliente");
            Console.WriteLine("******************");
            Console.WriteLine("");

            Clientes cliente = PerguntasPadraoCliente();

            repoCliente.Incluir(cliente, "clientes_spi");
            Console.ReadKey();
        }
        #endregion

        #region PerguntasPadraoCliente
        private static Clientes PerguntasPadraoCliente()
        {
            Clientes cliente = new Clientes();

            Console.WriteLine("Qual o nome do Cliente?");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Qual a especie do Cliente? (Humano|Marciano|Jupteriano)");
            cliente.Especie = Console.ReadLine();

            Console.WriteLine("Qual o documento do Cliente?");
            cliente.Documento = Console.ReadLine();

            Console.WriteLine("Qual a cor do Cliente?");
            cliente.Cor = Console.ReadLine();

            Console.WriteLine("Quantos braços tem o Cliente?");
            cliente.QtdBracos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Quantas pernas tem o Cliente?");
            cliente.QtdPernas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Quantas cabeças tem o Cliente?");
            cliente.QtdCabecas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Respira? (s|n)");
            string respira = Console.ReadLine();
            if (!respira.Equals("s") && !respira.Equals("n"))
            {
                throw new System.ArgumentException("Valor diferente de 's' ou 'n'", "Valor Diferente");
            }
            cliente.Respira = respira.ToLower() == "s" ? true : false;

            return cliente;
        } 
        #endregion

        #region MenuConsultaOpcao
        private static void MenuConsultaOpcao(string nomeEntidade)
        {
            string opcaoConsultar = HeaderOpcaoConsultar(nomeEntidade);
            if (opcaoConsultar == "1")
            {
                if (nomeEntidade.ToLower() == "planeta")
                {
                    // CONSULTA TODOS PLANETAS
                    PlanetaRepository repoPlaneta = new PlanetaRepository();
                    foreach (var item in repoPlaneta.Listar("planetasTodos_sps"))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ID: {0} - Planeta: {1}", item.Id, item.Nome);
                        Console.WriteLine("Descrição: {0}", item.Descricao);
                        Console.WriteLine("Possui Oxiênio? {0}", item.PossuiOxigenio == true ? "Sim" : "Não");
                        Console.WriteLine("*********************************************************************");
                    }
                }
                else if (nomeEntidade.ToLower() == "cliente")
                {
                    // CONSULTA TODOS CLIENTES
                    ClienteRepository repoCliente = new ClienteRepository();
                    foreach (var item in repoCliente.Listar("clientesTodos_sps"))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ID: {0} - Cliente: {1} | Especie: {2} | Documento: {3}", item.Id, item.Nome, item.Especie, item.Documento);
                        Console.WriteLine("Cor: {0} | {1} Braço(s) | {2} Perna(s) | {3} Cabeça(s)", item.Cor, item.QtdBracos, item.QtdPernas, item.QtdCabecas);
                        Console.WriteLine("Respira? {0}", item.Respira == true ? "Sim" : "Não");
                        Console.WriteLine("*********************************************************************");
                    }
                }
                else if (nomeEntidade.ToLower() == "transporte")
                {
                    // CONSULTA TODOS TRANSORTES
                }
                else if (nomeEntidade.ToLower() == "viagem")
                {
                    // CONSULTA TODAS VIAGENS DISPONIVEIS
                    ConsultaTodasViagensDisponiveis();
                }

                Console.ReadKey();
            }
            else if (opcaoConsultar == "2")
            {               

                if (nomeEntidade.ToLower() == "planeta")
                {
                    // CONSULTA PLANETA POR NOME
                    Console.WriteLine("Qual o nome do(a) {0}?", nomeEntidade);
                    string nome = Console.ReadLine();
                    MostraConsultaPlanetaPorNome(nome);
                }
                else if (nomeEntidade.ToLower() == "cliente")
                {
                    // CONSULTA CLIENTE POR NOME
                    Console.WriteLine("Qual o nome do(a) {0}?", nomeEntidade);
                    string nome = Console.ReadLine();
                    MostraConsultaClientePorNome(nome);
                }
                else if (nomeEntidade.ToLower() == "transporte")
                {
                    // CONSULTA TRANSPORTE POR NOME
                }
                else if (nomeEntidade.ToLower() == "viagem")
                {
                    // CONSULTA VIAGEM POR NOME
                    ViagemDiponivelRepository repoViagem = new ViagemDiponivelRepository();

                    Console.WriteLine("Informe o planeta de origem ou destino:");
                    string planeta = Console.ReadLine();

                    foreach (var item in repoViagem.ObterViagens(planeta, "viagensDispPorNome_sps"))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ID: {0} - Planeta Origem: {1} | Planeta Destino: {2} | Valor: {3} | Distancia: {4} Anos-luz",
                            item.Id, item.PlanetaOrigem, item.PlanetaDestino, item.Valor, item.Tempo);
                        Console.WriteLine("*********************************************************************");
                    }

                }
                Console.ReadKey();
            }
        }

        private static void ConsultaTodasViagensDisponiveis()
        {
            ViagemDiponivelRepository repoViagem = new ViagemDiponivelRepository();
            foreach (var item in repoViagem.Listar("viagensDispTodos_sps"))
            {
                Console.WriteLine("");
                Console.WriteLine("ID: {0} - Planeta Origem: {1} | Planeta Destino: {2} | Valor: {3} | Distancia: {4} Anos-luz",
                    item.Id, item.PlanetaOrigem, item.PlanetaDestino, item.Valor, item.Tempo);
                Console.WriteLine("*********************************************************************");
            }
        }

        private static void MostraConsultaClientePorNome(string nome)
        {
            ClienteRepository repoCliente = new ClienteRepository();
            Clientes cliente = repoCliente.Obter(nome, "clientesPorNome_sps");

            Console.WriteLine("");
            Console.WriteLine("Cliente: {0} | Especie: {1} | Documento: {2}", cliente.Nome, cliente.Especie, cliente.Documento);
            Console.WriteLine("Cor: {0} | {1} Braço(s) | {2} Perna(s) | {3} Cabeça(s)", cliente.Cor, cliente.QtdBracos, cliente.QtdPernas, cliente.QtdCabecas);
            Console.WriteLine("Respira? {0}", cliente.Respira == true ? "Sim" : "Não");
            Console.WriteLine("*********************************************************************");
        }
        #endregion

        #region MostraConsultaPorNome
        private static void MostraConsultaPlanetaPorNome(string nome)
        {
            PlanetaRepository repoPlaneta = new PlanetaRepository();
            Planetas planeta = repoPlaneta.Obter(nome, "planetasPorNome_sps");

            Console.WriteLine("");
            Console.WriteLine("ID: {0} - Planeta: {1}", planeta.Id, planeta.Nome);
            Console.WriteLine("Descrição: {0}", planeta.Descricao);
            Console.WriteLine("Possui Oxiênio? {0}", planeta.PossuiOxigenio == true ? "Sim" : "Não");
            Console.WriteLine("*********************************************************************");
        }
        #endregion

        #region HeaderOpcaoConsultar
        private static string HeaderOpcaoConsultar(string elem)
        {
            Console.WriteLine("Menu 2-1 - Consultar " + elem);
            Console.WriteLine("*****************************************");
            Console.WriteLine("1 - Consultar todos(as) os(as) {0}s", elem);
            Console.WriteLine("2 - Consultar pelo nome do(a) {0}", elem);
            return Console.ReadLine();
        }
        #endregion

        #region CadastarPlaneta
        private static void CadastarPlaneta()
        {
            PlanetaRepository repoPlaneta = new PlanetaRepository();


            Console.WriteLine("Menu 1-1 - Cadastrar Planeta");
            Console.WriteLine("******************");
            Console.WriteLine("");

            Planetas planeta = PerguntasPadraoPlaneta();

            repoPlaneta.Incluir(planeta, "planetas_spi");
            Console.ReadKey();
        }
        #endregion

        #region PerguntasPadraoPlaneta
        private static Planetas PerguntasPadraoPlaneta()
        {
            Planetas planeta = new Planetas();

            Console.WriteLine("Digite o nome do planeta?");
            planeta.Nome = Console.ReadLine();

            Console.WriteLine("Escreva a descrição do planeta?");
            planeta.Descricao = Console.ReadLine();

            Console.WriteLine("Esse planeta possui oxigenio? (s/n)");
            string possuiOxigenio = Console.ReadLine();

            if (!possuiOxigenio.Equals("s") && !possuiOxigenio.Equals("n"))
            {
                throw new System.ArgumentException("Valor diferente de 's' ou 'n'", "Valor Diferente");
            }
            planeta.PossuiOxigenio = possuiOxigenio.ToLower() == "s" ? true : false;

            return planeta;
        } 
        #endregion

        private static string MenuConsulta()
        {
            Header();
            Console.WriteLine("Menu 2 - Consultar");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Consultar Planeta");
            Console.WriteLine("2 - Consultar Cliente");
            Console.WriteLine("3 - Consultar Transporte");
            Console.WriteLine("4 - Consultar Viagens Disponiveis");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }

        private static string MenuCadastro()
        {
            Header();
            Console.WriteLine("Menu 1 - Cadastro");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Cadastrar Planeta");
            Console.WriteLine("2 - Cadastrar Cliente");
            Console.WriteLine("3 - Cadastrar Transporte");
            Console.WriteLine("4 - Cadastrar Viagem Disponível");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }

        private static string MenuAtualizar()
        {
            Header();
            Console.WriteLine("Menu 3 - Atualizar");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Atualizar Planeta");
            Console.WriteLine("2 - Atualizar Cliente");
            Console.WriteLine("3 - Atualizar Transporte");
            Console.WriteLine("4 - Atualizar Viagem");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }

        private static string MenuExcluir()
        {
            Header();
            Console.WriteLine("Menu 4 - Excluir");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Excluir Planeta");
            Console.WriteLine("2 - Excluir Cliente");
            Console.WriteLine("3 - Excluir Transporte");
            Console.WriteLine("4 - Excluir Viagem");
            Console.WriteLine("v - Voltar");
            return Console.ReadLine();
        }
        private static void Header()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao Sistema de Viagens Interplanetárias!");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
        }

        private static string MenuPrincipal()
        {
            Header();
            Console.WriteLine("Menu");
            Console.WriteLine("******************");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Consultar");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("******************");
            Console.WriteLine("5 - Fazer Booking da Viagem");
            Console.WriteLine("");
            Console.WriteLine("x - Encerrar");
            return Console.ReadLine();
        }
    }
}
