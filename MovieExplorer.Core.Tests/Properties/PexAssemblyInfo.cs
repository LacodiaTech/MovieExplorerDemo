// <copyright file="PexAssemblyInfo.cs">Copyright ©  2014</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("MovieExplorer.Core")]
[assembly: PexInstrumentAssembly("System.Net.Primitives")]
[assembly: PexInstrumentAssembly("System.Collections")]
[assembly: PexInstrumentAssembly("PCLStorage.Abstractions")]
[assembly: PexInstrumentAssembly("System.Text.Encoding")]
[assembly: PexInstrumentAssembly("System.IO")]
[assembly: PexInstrumentAssembly("PCLStorage")]
[assembly: PexInstrumentAssembly("System.Net.Http")]
[assembly: PexInstrumentAssembly("System.Resources.ResourceManager")]
[assembly: PexInstrumentAssembly("System.Runtime")]
[assembly: PexInstrumentAssembly("System.Threading.Tasks")]
[assembly: PexInstrumentAssembly("System.Diagnostics.Debug")]
[assembly: PexInstrumentAssembly("Newtonsoft.Json")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Net.Primitives")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Collections")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "PCLStorage.Abstractions")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Text.Encoding")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.IO")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "PCLStorage")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Net.Http")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Resources.ResourceManager")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Runtime")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Threading.Tasks")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Diagnostics.Debug")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Newtonsoft.Json")]

