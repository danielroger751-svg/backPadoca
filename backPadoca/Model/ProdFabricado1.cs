namespace backPadoca.Model
{
    internal class ProdFabricado
    {
        private int produto;
        private string? descricaoProducao;

        public ProdFabricado(int Produto, string? descricaoProducao)
        {
            produto = Produto;
            this.descricaoProducao = descricaoProducao;
        }
    }
}