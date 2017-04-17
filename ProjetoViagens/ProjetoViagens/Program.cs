using ProjetoViagens.Data;
using ProjetoViagens.DB.Base;
using ProjetoViagens.Logs;
using ProjetoViagens.Menus;
using ProjetoViagens.Model;
using ProjetoViagens.Model.DTO;
using ProjetoViagens.Telas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


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
                        //CONSULTAR TICKETS
                        ConsultaTickets();
                    }
                    else if (opcaoMenuBooking == "4")
                    {
                        //ATUALIZAR BOOKING
                        AtualizaBooking();
                    }
                    else if (opcaoMenuBooking == "5")
                    {
                        //EXCLUIR BOOKING
                        //TODO: excluir booking
                    }                    
                    Console.ReadKey();
                }
                else if (opcaoMenuPrincipal == "6")
                {
                    //EXIBIR LOGS ERRO
                    Console.Clear();
                    Console.WriteLine("**************************LOGS DE ERRO**************************");
                    string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string directoryLogsPath = rootPath + @"\Logs\Erro";

                    if (Directory.Exists(directoryLogsPath))
                    {
                        try
                        {
                            IEnumerable<string> filesInPath = Directory.EnumerateFiles(directoryLogsPath);

                            if (filesInPath.LongCount() > 0)
                            {
                                foreach (var item in filesInPath)
                                {
                                    StreamReader streamReader = File.OpenText(item);

                                    string line;

                                    Console.WriteLine("");
                                    while ((line = streamReader.ReadLine()) != null)
                                    {
                                        Console.WriteLine(line);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não foi encontrado nenhum arquivo de log de erro!");
                            }
                        }
                        catch (Exception ex)
                        {
                            LogErro.ExecuteLogErro("Erro ao ler arquivo. StackTrace: " + ex.StackTrace + 
                                " Mensagem de erro: " + ex.Message);
                        }
                    }
                }
                Console.ReadLine();
            } while (opcaoMenuPrincipal.ToLower() != "x");
        }
        
        #region ConsultaTickets
        private static void ConsultaTickets()
        {
            ClienteRepository repoCliente = new ClienteRepository();
            Clientes cliente = new Clientes();

            Console.WriteLine("*****************************CONSULTA VIAGEM********************************************");
            foreach (var item in repoCliente.Listar("clientesTodos_sps"))
            {
                Console.WriteLine("");
                Console.WriteLine("ID: {0} - Cliente: {1} | Especie: {2} | Documento: {3}", item.Id, item.Nome, item.Especie, item.Documento);
                Console.WriteLine("Cor: {0} | {1} Braço(s) | {2} Perna(s) | {3} Cabeça(s)", item.Cor, item.QtdBracos, item.QtdPernas, item.QtdCabecas);
                Console.WriteLine("Respira? {0}", item.Respira == true ? "Sim" : "Não");
                Console.WriteLine("*********************************************************************");
            }

            Console.WriteLine("Qual o Id do cliente que deseja consultar?");
            int id = Convert.ToInt32(Console.ReadLine());

            cliente = repoCliente.ObterPorId(id, "clientesPorId_sps");

            if (cliente.Id > 0)
            {
                string rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string directoryLogsPath = rootPath + @"\Logs\Clientes";

                string clienteNomeId = cliente.Nome + "_" + cliente.Id.ToString();
                string clientDirectory = Path.Combine(directoryLogsPath, clienteNomeId);

                if (Directory.Exists(clientDirectory))
                {
                    try
                    {
                        IEnumerable<string> filesInPath = Directory.EnumerateFiles(clientDirectory);

                        if (filesInPath.LongCount() > 0)
                        {
                            foreach (var item in filesInPath)
                            {
                                StreamReader streamReader = File.OpenText(item);

                                string line;

                                Console.WriteLine("");
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                                Console.WriteLine("***");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não foi encontrado nenhum ticket para o cliente!");
                        }
                    }
                    catch (Exception ex)
                    {
                        LogErro.ExecuteLogErro("Erro ao ler arquivo. StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                        Console.WriteLine("Erro ao ler arquivo, consulte o log de erro para mais detalhes.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhuma pasta para o cliente!");
            }
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
           
            try
            {
                repoPlaneta.Incluir(planeta, "planetas_spi");
            }
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao cadastrar planeta: " + planeta.Nome +
                    " Descrição: " + planeta.Descricao + " Possui oxigênio: " + planeta.PossuiOxigenio.ToString() +
                    ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao cadastrar planeta, consulte o log de erro para mais detalhes.");
            }
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
            try
            {
                repoCliente.Incluir(cliente, "clientes_spi");
            }
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao cadastrar cliente nome: " + cliente.Nome +
                    " terreno: " + cliente.Documento + ". StackTrace: " + ex.StackTrace +
                    " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao cadastrar cliente, consulte o log de erro para mais detalhes.");
            }
        }
        #endregion

        #region CadastraTransporte
        private static void CadastraTransporte()
        {
            TransporteRepository repoTransporte = new TransporteRepository();
            Transportes trasnporte = new Transportes();

            try
            {
                Console.WriteLine("Qual o nome do transporte?");
                trasnporte.Nome = Console.ReadLine();

                Console.WriteLine("Qual o terreno do transporte?");
                trasnporte.Terreno = Console.ReadLine();

                repoTransporte.Incluir(trasnporte, "transportes_spi");
            }
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao cadastrar transporte nome: " + trasnporte.Nome +
                    " terreno: " + trasnporte.Terreno + ". StackTrace: " + ex.StackTrace +
                    " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao cadastrar transporte, consulte o log de erro para mais detalhes.");
            }
        }
        #endregion

        #region CadastraViagem
        private static void CadastraViagem()
        {
            ViagensDispo viagemDispo = new ViagensDispo();
            ViagemDiponivelRepository repoViagemDispo = new ViagemDiponivelRepository();

            try
            {
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
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao cadastrar viagem. Planeta Origem: " + viagemDispo.PlanetaOrigem +
                    " Planeta Destino: " + viagemDispo.PlanetaDestino + ". StackTrace: " + ex.StackTrace + 
                    " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao cadastrar viagem, consulte o log de erro para mais detalhes.");
            }
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

                Console.WriteLine("Tem certeza que deseja atualizar? (s/n)");
                string opcaoCerteza = Console.ReadLine();

                if (opcaoCerteza.Equals("s"))
                {
                    Planetas planeta = PerguntasPadraoPlaneta();
                    
                    try
                    {
                        repoPlaneta.Atualizar(planeta, "planetas_upd");
                    }
                    catch (Exception ex)
                    {
                        LogErro.ExecuteLogErro("Erro ao atualizar planeta ID: " + planeta.Id.ToString() +
                            ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                        Console.WriteLine("Erro ao atualizar planeta, consulte o log de erro para mais detalhes.");
                    }
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

                Console.WriteLine("Tem certeza que deseja atualizar? (s/n)");
                string opcaoCerteza = Console.ReadLine();

                if (opcaoCerteza.Equals("s"))
                {
                    Clientes cliente = PerguntasPadraoCliente();
                    
                    try
                    {
                        repoCliente.Atualizar(cliente, "clientes_upd");
                    }
                    catch (Exception ex)
                    {
                        LogErro.ExecuteLogErro("Erro ao atualizar cliente ID: " + cliente.Id.ToString() +
                            ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                        Console.WriteLine("Erro ao atualizar cliente, consulte o log de erro para mais detalhes.");
                    }
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
            try
            {
                MostrarConsulta.MostraTodosTransportes();

                Console.WriteLine("");
                Console.WriteLine("Informe o ID do transporte que deseja atualizar:");
                transportes.Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe o novo Nome do transporte que deseja atualizar:");
                transportes.Nome = Console.ReadLine();

                Console.WriteLine("Informe o novo Terreno do transporte que deseja atualizar:");
                transportes.Terreno = Console.ReadLine();

                repoTransporte.Atualizar(transportes, "transprte_upd");
            }
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao atualizar transporte ID: " + transportes.Id.ToString() +
                    ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao atualizar transporte, consulte o log de erro para mais detalhes.");
            }
        }
        #endregion

        #region AtualizaViagemDisponivel
        private static void AtualizaViagemDisponivel()
        {
            ViagensDispo viagemDispo = new ViagensDispo();
            try
            {                
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
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao atualizar viagem disponivel ID: " + viagemDispo.Id.ToString() +
                    ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao atualizar viagem, consulte o log de erro para mais detalhes.");
            }
        }
        #endregion

        #region AtualizaBooking
        private static void AtualizaBooking()
        {
            /*
             * Obs.: Para facilitar e enxutar o código optei por passar o ID de cliente,
             * viagem disponível e transporte diretamente.
             */
            ViagemCliente viagemCliente = new ViagemCliente();
            try
            {
                BookingRepository repoBookinge = new BookingRepository();

                Console.WriteLine("Informe o ID do booking para ser atualizado");
                viagemCliente.CodigoReserva = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe o novo ID da Viagem Disponível para ser atualizado");
                viagemCliente.IdViagemDispo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe o novo ID do Cliente para ser atualizado");
                viagemCliente.IdCliente = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe o novo ID do Transporte para ser atualizado");
                viagemCliente.IdTransporte = Convert.ToInt32(Console.ReadLine());

                repoBookinge.Atualizar(viagemCliente, "booking_upd");
            }
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao atualizar booking Código da reserva: " +
                    viagemCliente.CodigoReserva.ToString() + ". StackTrace: " + ex.StackTrace +
                    " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao atualizar viagem, consulte o log de erro para mais detalhes.");
            }
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
                
                try
                {
                    repoPlaneta.Excluir(id, "planetas_del");
                }
                catch (Exception ex)
                {
                    LogErro.ExecuteLogErro("Erro ao excluir planeta ID: " + id.ToString() +
                    ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Erro ao excluir planeta, consulte o log de erro para mais detalhes.");
                }
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
                
                try
                {
                    repoCliente.Excluir(id, "clientes_del");
                }
                catch (Exception ex)
                {
                    LogErro.ExecuteLogErro("Erro ao excluir cliente ID: " + id.ToString() +
                    ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Erro ao excluir cliente, consulte o log de erro para mais detalhes.");
                }
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
                
                try
                {
                    repoTransporte.Excluir(id, "transportes_del");
                }
                catch (Exception ex)
                {
                    LogErro.ExecuteLogErro("Erro ao excluir transporte do cliente ID: " + id.ToString() +
                    ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Erro ao excluir transporte, consulte o log de erro para mais detalhes.");
                }
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
                
                try
                {
                    repoViagemDispo.Excluir(id, "viagem_del");
                }
                catch (Exception ex)
                {
                    LogErro.ExecuteLogErro("Erro ao excluir viagem do cliente ID: " + id.ToString() +
                    ". StackTrace: " + ex.StackTrace + " Mensagem de erro: " + ex.Message);
                    Console.WriteLine("Erro ao excluir viagem, consulte o log de erro para mais detalhes.");
                }
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
            try
            {               
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
            catch (Exception ex)
            {
                LogErro.ExecuteLogErro("Erro ao fazer o booking do cliente ID: "+ viagemCliente.IdCliente.ToString() + 
                    ". StackTrace: "+ ex.StackTrace + " Mensagem de erro: " + ex.Message);
                Console.WriteLine("Erro ao ler arquivo, consulte o log de erro para mais detalhes.");
            }
            

            
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
                LogErro.ExecuteLogErro("Valor diferente de 's' ou 'n' se cliente: "+ cliente.Nome + " respira");
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
                LogErro.ExecuteLogErro("Valor diferente de 's' ou 'n' se planeta possui oxigênio");
                throw new System.ArgumentException("Valor diferente de 's' ou 'n'", "Valor Diferente");
            }
            planeta.PossuiOxigenio = possuiOxigenio.ToLower() == "s" ? true : false;

            return planeta;
        }
        #endregion
    }
}
