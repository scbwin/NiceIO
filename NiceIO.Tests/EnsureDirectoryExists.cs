﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Path=NiceIO.Path;

namespace NiceIO.Tests
{
	[TestFixture]
	public class EnsureDirectoryExists : TestWithTempDir
	{
		[Test]
		public void CreatesDirectory()
		{
			_tempPath.Combine("subdir").EnsureDirectoryExists();

			AssertTempDir(new[] { "subdir/"});
		}

		[Test]
		public void ExistingDirectory()
		{
			PopulateTempDir(new[ ]{ "subdir/"});
			_tempPath.Combine("subdir").EnsureDirectoryExists();
			AssertTempDir(new[] { "subdir/" });
		}

		[Test]
		public void CreatesDirectoryWithArgument()
		{
			_tempPath.EnsureDirectoryExists("subdir");
			AssertTempDir(new[] { "subdir/" });
			AssertTempDir(new[] { "subdir/" });
		}

		[Test]
		public void EnsureParentDirectoryExists()
		{
			_tempPath.Combine("subdir1/subdir2/myfile").EnsureParentDirectoryExists();

			AssertTempDir(new[] { "subdir1/","subdir1/subdir2/" });
		}
	}
}
