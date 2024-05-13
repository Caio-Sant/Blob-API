using System;
using App.Infra.Data.Context;

namespace App.Infra.Data.Factory;

public interface IImagemContextFactory
{
	ImagemContext Create();
}

