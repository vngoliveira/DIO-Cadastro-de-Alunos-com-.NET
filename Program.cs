using System;

namespace DIO_Idiomas
{
    class Program
    {
        static CursosRepositorio repositorio = new CursosRepositorio();
        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario(); 
          while(opcaoUsuario.ToUpper()!="X")
          {
              switch(opcaoUsuario)
              {
                  case "1":
                  ListarCursos();
                  break;
                  case "2":
                  InserirCursos();
                  break;
                  case "3":
                  AtualizarCursos();
                  break;
                  case "4":
                  ExcluirCursos();
                  break;
                  case "5":
                  VisualizarCursos();
                  break;
                  case "C":
                  Console.Clear();
                  break;

                  default:
                  throw new ArgumentOutOfRangeException();
              }
              opcaoUsuario=ObterOpcaoUsuario();
          } 
          Console.WriteLine("Encerramento do Programa. Agradecemos por acessar nosso Sistema.");
          Console.ReadLine();
        }
        private static void ListarCursos()
        {
            Console.WriteLine("Listar matriculados");
            var lista=repositorio.Lista();
            if(lista.Count==0)
            {
                Console.WriteLine("Nenhuma matrícula cadastrada");
                return;
            }
            foreach(var cursos in lista)
            {
                Console.WriteLine("#ID matrícula {0}: - {1}", cursos.retornaId(), cursos.retornaAluno());
            }
        }
        private static void InserirCursos()
        {
            Console.WriteLine("Inserir novo aluno");
            foreach(int i in Enum.GetValues(typeof(Idiomas)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Idiomas),i));
            }
            Console.WriteLine("Digite o idioma dentre as opções acima que deseja cadastrar: ");
            int entradaIdioma=int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do aluno que será matriculado: ");
            string entradaAluno=Console.ReadLine();

            Console.WriteLine("Digite o turno que o aluno estudará: ");
            string entradaTurno=Console.ReadLine();

            Console.WriteLine("Digite o nível que o aluno iniciará no curso: ");
            string entradaNivel=Console.ReadLine();

            Cursos novoCurso=new Cursos(id: repositorio.ProximoId(),
                                        idiomas: (Idiomas)entradaIdioma,
                                        aluno: entradaAluno,
                                        turno: entradaTurno,
                                        nivel: entradaNivel);
            repositorio.Insere(novoCurso);
        }
        private static void AtualizarCursos()
        {
            Console.WriteLine("Digite a matrícula do aluno: ");
            int indicematricula=int.Parse(Console.ReadLine());
            foreach(int i in Enum.GetValues(typeof(Idiomas)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Idiomas),i));
            }
            Console.WriteLine("Digite o idioma dentre as opções acima que deseja cadastrar: ");
            int entradaIdioma=int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do aluno que será matriculado: ");
            string entradaAluno=Console.ReadLine();

            Console.WriteLine("Digite o turno que o aluno estudará: ");
            string entradaTurno=Console.ReadLine();

            Console.WriteLine("Digite o nível que o aluno iniciará no curso: ");
            string entradaNivel=Console.ReadLine();

            Cursos atualizaCurso=new Cursos(id: indicematricula,
                                            idiomas: (Idiomas)entradaIdioma,
                                            aluno: entradaAluno,
                                            turno: entradaTurno,
                                            nivel: entradaNivel);
            
            repositorio.Atualiza(indicematricula, atualizaCurso);
        }
        private static void ExcluirCursos()
        {
            Console.WriteLine("Digite a matrícula do aluno: ");
            int indicematricula=int.Parse(Console.ReadLine());

            repositorio.Exclui(indicematricula);
        }
        private static void VisualizarCursos()
        {
            Console.WriteLine("Digite a matrícula do aluno: ");
            int indicematricula=int.Parse(Console.ReadLine());

            var cursos=repositorio.RetornaPorId(indicematricula);

            Console.WriteLine(cursos);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Escola de Idiomas Babel");
            Console.WriteLine("Informe a ação que deseja realizar: ");
            Console.WriteLine("1- Listar matriculados");
            Console.WriteLine("2- Inserir novo aluno");
            Console.WriteLine("3- Atualizar ficha de matriculados");
            Console.WriteLine("4- Excluir matrícula");
            Console.WriteLine("5- Visualizar Cursos");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario=Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
