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

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite != null && hospedes != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("O número de hóspedes excede a capacidade da suíte ou os dados são inválidos.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null || DiasReservados < 0)
            {
                throw new InvalidOperationException("Suíte não cadastrada ou dias reservados inválidos.");
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica desconto de 10%
            }

            return valor;
        }
    }
}