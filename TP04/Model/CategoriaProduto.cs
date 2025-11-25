using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum CategoriaProduto
    {
        Mercearia,
        Hortifruti,
        Bebidas,
        Limpeza,
        Higiene,
        Padaria,
        Carnes
    }

    // 2. A Classe de Extensão (A lógica do mapa da imagem)
    public static class CategoriaExtensions
    {

        private static Dictionary<string, CategoriaProduto> mapa =
            new Dictionary<string, CategoriaProduto>
            {
                { "Mercearia", CategoriaProduto.Mercearia },
                { "Hortifruti", CategoriaProduto.Hortifruti },
                { "Bebidas", CategoriaProduto.Bebidas },
                { "Limpeza", CategoriaProduto.Limpeza },
                { "Higiene", CategoriaProduto.Higiene },
                { "Padaria", CategoriaProduto.Padaria },
                { "Carnes", CategoriaProduto.Carnes }
            };
        public static string ParaString(this CategoriaProduto tipo)
        {
            return mapa.First(s => s.Value == tipo).Key;
        }
        public static CategoriaProduto ParaTipo(this string texto)
        {
            if (!mapa.ContainsKey(texto)) return CategoriaProduto.Mercearia;

            return mapa.First(t => t.Key == texto).Value;
        }
    }
}
