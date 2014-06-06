using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList.Core.Tests.Services;
using ShoppingList.Core.ViewModels;

namespace ShoppingList.Core.Tests.Tests
{
    [TestClass]
    public class UnitTest1
    {
[TestMethod]
public void AddProductTest() {
    var messenger = new MvxMessengerHub();
    var stateService = new StateServiceTest();
    var addProductViewModel = 
        new AddProductViewModel(messenger, stateService) {
        Name = "NewProduct",
        Amount = "1"
    };

    addProductViewModel.SaveProductCommand.Execute();

    var list = stateService.SelectedList;
    Assert.AreEqual(1, list.Products.Count);
    Assert.AreEqual("NewProduct", list.Products[0].Name);
    Assert.AreEqual("1", list.Products[0].Amount);
}
    }
}
