using System.Dynamic;
namespace Logic;

public class Initialization{
    public Initialization(){}
    public static async Task<bool> ReadyToRun(){
        return await Task.FromResult(true);
    }

   
}