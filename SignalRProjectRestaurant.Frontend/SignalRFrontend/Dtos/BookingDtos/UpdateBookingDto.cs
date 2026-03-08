using System.ComponentModel.DataAnnotations;

namespace SignalRFrontend.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^5\d{9}$", ErrorMessage = "Telefon numarası 5 ile başlamalı ve 10 haneli olmalıdır.")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Kişi sayısı alanı zorunludur.")]
        public int PersonCount { get; set; }
        [Required(ErrorMessage = "Tarih alanı zorunludur.")]
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
