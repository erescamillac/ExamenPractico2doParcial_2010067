using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExamenPractico2doParcial_2010067
{
    /*
     * @author: Erick Escamilla Charco
     */
    public class InputReader {
        public InputReader() {
        }

        public byte ReadAge(string inputMsg, string errMsg) {
            byte age = 0;
            string strFromKeyboard;
            bool parsingSuccess, error = false;

            do {
                if (error) {
                    Console.Error.WriteLine(errMsg);
                }
                Console.WriteLine(inputMsg);
                strFromKeyboard = Console.ReadLine();
                parsingSuccess = Byte.TryParse(strFromKeyboard, out age);
                if (!parsingSuccess)
                {
                    error = true;
                }
                else {
                    error = false;
                }
            } while (error);

            

            return age;
        }//--fin: ReadAge()

        public string ReadName(string inputMsg) {
            string name = "";
            Console.WriteLine(inputMsg);
            name = Console.ReadLine();
            return name;
        }

    }
    class Program
    {
        static int CalcularPagoInscripcion(string name, byte age) {
            int fee = 0;
            if (age < 18) {
                fee = 3800;
            } else if (age >= 18 && age < 60) {
                fee = 4300;
            }
            else {
                fee = 3500;
            }
            Console.WriteLine("{0}, tu pago deberá ser de ${1}", name, fee);
            return fee;
        }
        static void Main(string[] args)
        {
            InputReader iReader = new InputReader();
            char continuar = 'n';
            string name;
            int pago;
            byte age;
            do {
                Console.Clear();
                Console.WriteLine("##--Cálculo de pago de inscripción.--##");
                name = iReader.ReadName("Ingrese su nombre: ");
                age = iReader.ReadAge("Ingrese su edad como un ENTERO entre 0 y 255: ", "EL valor ingresado NO es un número ENTERO valido entre 0 y 255");
                pago = CalcularPagoInscripcion(name, age);
                Console.WriteLine("\t¿Desea calcular otro pago de inscripción? [y/n]: ");
                continuar = Console.ReadKey().KeyChar;
            } while (Char.ToLower(continuar).Equals('y'));
            Console.WriteLine("\n\nHasta la próxima...");
            Thread.Sleep(1600);
        }
    }
}
