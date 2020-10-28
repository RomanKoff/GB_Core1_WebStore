using WebStore.App01.ViewModels;

namespace WebStore.App01.Services.Interfaces
{

	public interface ICartService
	{
		CartViewModel TransformCart();

		void AddToCart(int id);
		void DecrementFromCart(int id);
		void RemoveFromCart(int id);
		void RemoveAll();		
	}

}