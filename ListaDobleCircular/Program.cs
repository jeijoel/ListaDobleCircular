namespace ListaDobleCircular
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista miLista = new ListaSimpleCircular();
            //miLista.Anadir(0);
            //Console.WriteLine(miLista.Contiene(1));
            //Console.WriteLine(miLista.RevisarVacio());
            //miLista.AnadirInicio(2);
            //miLista.AnadirInicio(1);
            //Console.WriteLine(miLista.Contiene(0));
            //miLista.AnadirFinal(3);
            //Console.WriteLine(miLista);
            Lista lista = new ListaDobleCircular();
            lista.AnadirInicio(1);
            lista.AnadirFinal(2);
            lista.AnadirInicio(3);
            Console.WriteLine(lista);
        }
    }
}
