using ProjetoViagens.Data;
using ProjetoViagens.DB.Base;
using ProjetoViagens.Logs;
using ProjetoViagens.Menus;
using ProjetoViagens.Model;
using ProjetoViagens.Model.DTO;
using ProjetoViagens.Telas;
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
                opcaoMenuPrincipal = MenuPrincipal.ShowMenuPrincipal();
                if (opcaoMenuPrincipal == "1")
                {
                    string opcaoMenuCadastro = MenuCadastrar.ShowMenuCadastrar();
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
                        CadastraTransporte();

                    }
                    else if (opcaoMenuCadastro == "4")
                    {
                        //CADASTRAR VIAGEM
                        CadastraViagem();
                    }
                    Console.ReadKey();
                }
                else if (opcaoMenuPrincipal == "2")
                {
                    string opcaoMenuConsulta = MenuConsultar.ShowMenuConsultar();
                    if (opcaoMenuConsulta == "1")
                    {
                        //CONSULTAR PLANETA
                        TelaConsultar.ShowTelaConsultar("Planeta");
                    }
                    else if (opcaoMenuConsulta == "2")
                    {
                        //CONSULTAR CLIENTE
                        TelaConsultar.ShowTelaConsultar("Cliente");
                    }
                    else if (opcaoMenuConsulta == "3")
                    {
                        //CONSULTAR TRANSPORTE
                        TelaConsultar.ShowTelaConsultar("Transporte");
                    }
                    else if (opcaoMenuConsulta == "4")
                    {
                        //CONSULTAR VIAGEM DISPONIVEIS
                        TelaConsultar.ShowTelaConsultar("Viagem");
                    }
                    Console.ReadKey();
                }
                else if (opcaoMenuPrincipal == "3")
                {
                    string opcaoMenuConsulta = MenuAtualizar.ShowMenuAtualizar();
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
                        AtualizaTransporte();
                    }
                    else if (opcaoMenuConsulta == "4")
                    {
                        //ATUALIZAR VIAGEM DISPONIVEIS
                        AtualizaViagemDisponivel();
                    }
                    Console.ReadKey();
                }
                else if (opcaoMenuPrincipal == "4")
                {
                    string opcaoMenuConsulta = MenuExcluir.ShowMenuExcluir();
                    if (opcaoMenuConsulta == "1")
                    {
                        //EXCLUIR PLANETA
                        ExcluiPlaneta();
                    }
                    else if (opcaoMenuConsulta == "2")
                    {
                        //EXCLUIR CLIENTE
                        ExcluiCliente();
                    }
                    else if (opcaoMenuConsulta == "3")
                    {
                        //EXCLUIR TRANSPORTE
                        ExcluiTransporte();
                    }
                    else if (opcaoMenuConsulta == "4")
                    {
                        //EXCLUIR VIAGEM
                        ExcluiViagemDisponivel();
                    }
                    Console.ReadKey();
                }
                else if (opcaoMenuPrincipal == "5")
                {
                    //BOOKING DA VIAGEM
                    string opcaoMenuBooking = MenuBooking.ShowMenuBooking();
                    if (opcaoMenuBooking == "1")
                    {
                        //FAZER BOOKING
                        FazerBooking();
                    }
                    else if (opcaoMenuBooking == "2")
                    {
                        //CONSULTAR BOOKING
                        string opcaoConsultaBoooking = MenuBookingConsultar.ShowMenuConsultarooking();
                        if (opcaoConsultaBoooking == "1")
                        {
                            //CONSULTAR BOOKING OPCAO 1
                            MostrarConsulta.ConsultaBookingTodos();
                        }
                        else if (opcaoConsultaBoooking == "2")
                        {
                            //CONSULTAR BOOKING OPCAO 2
                            MostrarConsulta.ConsultaBookingPorId();
                        }
                    }
                    else if (opcaoMenuBooking == "3")
                    {
                        //ATUALIZAR BOOKING
                        //TODO: atualizar booking
                    }
                    else if (opcaoMenuBooking == "4")
                    {
                        //EXCLUIR BOOKING
                        //TODO: excluir booking
                    }
                    Console.ReadKey();
                }
            } while (opcaoMenuPrincipal.ToLower() != "x");
        }

        #region CadastarPlaneta
        private static void CadastarPlaneta()
        {
            PlanetaRepository repoPlaneta = new PlanetaRepository();


            Console.WriteLine("Menu 1-1 - Cadastrar Planeta");
            Console.WriteLine("******************");
            Console.WriteLine("");

            Planetas planeta = PerguntasPadraoPlaneta();

            repoPlaneta.Incluir(planeta, "planetas_spi");
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
        }
        #endregion

        #region CadastraTransporte
        private static void CadastraTransporte()
        {
            TransporteRepository repoTransporte = new TransporteRepository();
            Transportes trasnporte = new Transportes();

            Console.WriteLine("Qual o nome do transporte?");
            trasnporte.Nome = Console.ReadLine();

            Console.WriteLine("Qual o terreno do transporte?");
            trasnporte.Terreno = Console.ReadLine();

            repoTransporte.Incluir(trasnporte, "transportes_spi");
        }
        #endregion

        #region CadastraViagem
        private static void CadastraViagem()
        {
            ViagensDispo viagemDispo = new ViagensDispo();
            ViagemDiponivelRepository repoViagemDispo = new ViagemDiponivelRepository();

            Console.WriteLine("");
            Console.WriteLine("Informe o planeta de origem:");
            viagemDispo.PlanetaOrigem = Console.ReadLine();

            Console.WriteLine("Informe o planeta de destino:");
            viagemDispo.PlanetaDestino = Console.ReadLine();

            Console.WriteLine("Informe o valor da viagem:");
            viagemDispo.Valor = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a distancia da viagem: (Anos-Luz)");
            viagemDispo.Tempo = Convert.ToInt32(Console.ReadLine());

            repoViagemDispo.Incluir(viagemDispo, "viagemDispo_spi");
        }
        #endregion

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
                MostrarConsulta.MostraConsultaPlanetaPorNome(nome);
                //MostraConsultaPlanetaPorNome(nome);

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

                MostrarConsulta.MostraConsultaClientePorNome(nome);
                //MostraConsultaClientePorNome(nome);

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

        #region AtualizaTransporte
        private static void AtualizaTransporte()
        {
            TransporteRepository repoTransporte = new TransporteRepository();
            Transportes transportes = new Transportes();
            MostrarConsulta.MostraTodosTransportes();
            //MostraTodosTransportes();
            Console.WriteLine("");
            Console.WriteLine("Informe o ID do transporte que deseja atualizar:");
            transportes.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o novo Nome do transporte que deseja atualizar:");
            transportes.Nome = Console.ReadLine();

            Console.WriteLine("Informe o novo Terreno do transporte que deseja atualizar:");
            transportes.Terreno = Console.ReadLine();

            repoTransporte.Atualizar(transportes, "transprte_upd");
        }
        #endregion

        #region AtualizaViagemDisponivel
        private static void AtualizaViagemDisponivel()
        {
            ViagensDispo viagemDispo = new ViagensDispo();
            ViagemDiponivelRepository repoViagemDispo = new ViagemDiponivelRepository();

            Console.WriteLine("Informe o ID da viagem disponivel para ser atualizado");
            viagemDispo.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o novo Planeta Origem para ser atualizado");
            viagemDispo.PlanetaOrigem = Console.ReadLine();

            Console.WriteLine("Informe o novo Planeta Destino para ser atualizado");
            viagemDispo.PlanetaDestino = Console.ReadLine();

            Console.WriteLine("Informe o novo Valor da viagem para ser atualizado");
            viagemDispo.Valor = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a novo Distancia(Anos-Luz) da viagem para ser atualizado");
            viagemDispo.Tempo = Convert.ToInt32(Console.ReadLine());

            repoViagemDispo.Atualizar(viagemDispo, "viagensDispo_upd");
        }
        #endregion

        #region ExcluiPlaneta
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
        }
        #endregion

        #region ExcluiCliente
        private static void ExcluiCliente()
        {
            Console.WriteLine("Informe o ID do Cliente para excluir:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tem certeza que deseja excluir? (s/n)");
            string opcaoCerteza = Console.ReadLine();

            if (opcaoCerteza.Equals("s"))
            {
                ClienteRepository repoCliente = new ClienteRepository();
                repoCliente.Excluir(id, "clientes_del");
            }
            else
            {
                Console.WriteLine("Cliente NÂO foi excluido!");
                Console.WriteLine("");
            }
        }
        #endregion

        #region ExcluiTransporte
        private static void ExcluiTransporte()
        {
            Console.WriteLine("Informe o ID do Transporte para excluir:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tem certeza que deseja excluir? (s/n)");
            string opcaoCerteza = Console.ReadLine();

            if (opcaoCerteza.Equals("s"))
            {
                TransporteRepository repoTransporte = new TransporteRepository();
                repoTransporte.Excluir(id, "transportes_del");
            }
            else
            {
                Console.WriteLine("Transporte NÂO foi excluido!");
                Console.WriteLine("");
            }
        }
        #endregion

        #region ExcluiViagemDisponivel
        private static void ExcluiViagemDisponivel()
        {
            Console.WriteLine("Informe o ID da Viagem para excluir:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tem certeza que deseja excluir? (s/n)");
            string opcaoCerteza = Console.ReadLine();

            if (opcaoCerteza.Equals("s"))
            {
                ViagemDiponivelRepository repoViagemDispo = new ViagemDiponivelRepository();
                repoViagemDispo.Excluir(id, "viagem_del");
            }
            else
            {
                Console.WriteLine("Viagem NÂO foi excluido!");
                Console.WriteLine("");
            }
        }
        #endregion

        #region FazerBooking
        private static void FazerBooking()
        {
            ViagemCliente viagemCliente = new ViagemCliente();
            Console.WriteLine("Informe o ID do Cliente:");
            viagemCliente.IdCliente = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("#################################### VIAGENS DISPONÍVEIS ###################################");
            Console.WriteLine("############################################################################################");
            MostrarConsulta.MostraTodasViagensDisponiveis();
            //MostraTodasViagensDisponiveis();
            Console.WriteLine("############################################################################################");
            Console.WriteLine("");

            Console.WriteLine("Informe o ID da Viagem Disponível:");
            viagemCliente.IdViagemDispo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("################################## TRANSPORTES DISPONÍVEIS #################################");
            Console.WriteLine("############################################################################################");
            MostrarConsulta.MostraTodosTransportes();
            //MostraTodosTransportes();
            Console.WriteLine("############################################################################################");
            Console.WriteLine("");

            Console.WriteLine("Informe o ID do Transporte Disponivel:");
            viagemCliente.IdTransporte = Convert.ToInt32(Console.ReadLine());

            BookingRepository repoBooking = new BookingRepository();

            viagemCliente = repoBooking.Incluir(viagemCliente, "viagemCliente_spi");

            LogCliente.ExecuteLogCliente(viagemCliente);
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
    }
}
