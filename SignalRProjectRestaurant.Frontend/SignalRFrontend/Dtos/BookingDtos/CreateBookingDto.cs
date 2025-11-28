using System.ComponentModel.DataAnnotations;

namespace SignalRFrontend.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Telefon numarası yalnızca rakamlardan oluşmalı ve 11 haneli olmalıdır.")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Kişi sayısı alanı zorunludur.")]
        public int PersonCount { get; set; }
        [Required(ErrorMessage = "Tarih alanı zorunludur.")]
        public DateTime Date { get; set; }
    }
}
