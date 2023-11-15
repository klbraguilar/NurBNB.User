using MediatR;
using Restaurant.SharedKernel.Core;


namespace NurBNB.Usuario.Domain.Model.CheckInOut.Events;

public record CheckOutRealizado : DomainEvent, INotification
{
    public Guid Id { get; init; }
    public Guid GuestId { get; set; }
    public Guid ReservaId { get; set; }
    public string ComentarioHuesped { get; set; }
    public DateTime FechaSalida { get; set; }
    public Calificacion Calificacion { get; set; }

    public CheckOutRealizado(Guid id, Guid guestId, Guid reservaId, Calificacion calificacion, DateTime fechaSalida, string comentarioHuesped) : base(DateTime.Now)
    {
        Id = id;
        GuestId = guestId;
        ReservaId = reservaId;
        Calificacion = calificacion;
        FechaSalida = fechaSalida;
        ComentarioHuesped = comentarioHuesped;
    }
}
