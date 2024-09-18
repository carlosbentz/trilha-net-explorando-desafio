namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        private void VerificarSuiteExiste()
        {
            if (Suite == null)
            {
                throw new Exception("Não existe uma suíte cadastrada.");
            }
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            VerificarSuiteExiste();
            int vagasRestantes = Suite.Capacidade - hospedes.Count;

            if (vagasRestantes >= 0)
            {
                Hospedes = hospedes;
            }

            else
            {
                throw new Exception($"A suíte não comporta essa quantidade de hóspedes. Vagas na suíte {Suite.Capacidade}, hóspedes pretendidos: {hospedes.Count}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes == null)
            {
                throw new Exception("Não existem hóspedes cadastrados.");
            }

            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            VerificarSuiteExiste();

            if (DiasReservados <= 0)
            {
                throw new Exception("A quantidade de dias reservados não foram informados ou é igual a zero.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor -= valor * 0.10M;
            }

            return valor;
        }
    }
}