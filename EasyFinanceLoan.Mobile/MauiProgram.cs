﻿using CommunityToolkit.Maui;
using EasyFinanceLoan.Mobile.Services;
using EasyFinanceLoan.Mobile.View;
using EasyFinanceLoan.Mobile.ViewModel;
using Microsoft.Extensions.Logging;

namespace EasyFinanceLoan.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>().UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
        });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<GenericService>();

        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<Loan1>();
        return builder.Build();
	}
}
