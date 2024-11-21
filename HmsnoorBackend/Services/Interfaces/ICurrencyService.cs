using HmsnoorBackend.Dtos;

namespace HmsnoorBackend.Services.Interfaces;

public interface ICurrencyService
{
    Task<List<CurrencyGetDto>> FindAll_Currency_Async();
    Task<CurrencyGetDto?> Find_ById_Async(int currencyId = 1);
    Task<CurrencyGetDto> Save_Currency_Async(CurrencyCreateDto dto);
    Task<CurrencyGetDto> Update_Currency_Async(int currencyId, CurrencyUpdateDto dto);
    Task<bool> Delete_Currency_Async(int currencyId = 1);

}
