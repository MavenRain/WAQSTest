param($installPath, $toolsPath, $package)

if (Test-Path "HKLM:\Software\Microsoft\Microsoft SDKs\Windows\v8.0A")
{
    $gacUtilFolder = Join-Path (Get-Item "HKLM:\Software\Microsoft\Microsoft SDKs\Windows\v8.0A").GetValue("InstallationFolder") "Bin\NETFX 4.0 Tools"
}
else
{
    if (Test-Path "HKLM:\Software\Microsoft\Microsoft SDKs\Windows\v7.0A")
    {
        $gacUtilFolder = Join-Path (Get-Item "HKLM:\Software\Microsoft\Microsoft SDKs\Windows\v7.0A").GetValue("InstallationFolder") "Bin\NETFX 4.0 Tools"
    }
    else
    {
        if (Test-Path "HKLM:\Software\Wow6432Node")
        {
            if (Test-Path "HKLM:\Software\Wow6432Node\Microsoft\Microsoft SDKs\Windows\v8.0A")
            {
                $gacUtilFolder = Join-Path (Get-Item "HKLM:\Software\Wow6432Node\Microsoft\Microsoft SDKs\Windows\v8.0A").GetValue("InstallationFolder") "Bin\NETFX 4.0 Tools"
            }
            else
            {
                if (Test-Path "HKLM:\Software\Wow6432Node\Microsoft\Microsoft SDKs\Windows\v7.0A")
                {
                    $gacUtilFolder = Join-Path (Get-Item "HKLM:\Software\Wow6432Node\Microsoft\Microsoft SDKs\Windows\v7.0A").GetValue("InstallationFolder") "Bin\NETFX 4.0 Tools"
                }
                else
                {
                    throw 'Registry Not Supported Exception'
                }
            }    
        }
        else
        {
            throw 'Registry Not Supported Exception'
        }
    }
}

$gacPath = Join-Path $env:windir "Microsoft.NET\assembly\GAC_MSIL"
$installRoslynPackage = $false

$dllGacPath = Join-Path $gacPath 'Roslyn.Compilers'
$dllName = 'Roslyn.Compilers.dll'
$dllVersion = '1.2.20906.1'
$install = $true
if (Test-Path $dllGacPath)
{
	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
	{
		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
		{
			$install = $false
		}
	}
}
if ($install -eq $true)
{
    $installRoslynPackage = $true
}
if ($installRoslynPackage -eq $false)
{
    $dllGacPath = Join-Path $gacPath 'Roslyn.Compilers.CSharp'
    $dllName = 'Roslyn.Compilers.CSharp.dll'
    $dllVersion = '1.2.20906.1'
    $install = $true
    if (Test-Path $dllGacPath)
    {
    	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
    	{
    		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
    		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
    		{
    			$install = $false
    		}
    	}
    }
    if ($install -eq $true)
    {
        $installRoslynPackage = $true
    }
}
if ($installRoslynPackage -eq $false)
{
    $dllGacPath = Join-Path $gacPath 'Roslyn.Services'
    $dllName = 'Roslyn.Services.dll'
    $dllVersion = '1.2.20906.1'
    $install = $true
    if (Test-Path $dllGacPath)
    {
    	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
    	{
    		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
    		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
    		{
    			$install = $false
    		}
    	}
    }
    if ($install -eq $true)
    {
        $installRoslynPackage = $true
    }
}
if ($installRoslynPackage -eq $false)
{
    $dllGacPath = Join-Path $gacPath 'Roslyn.Services.CSharp'
    $dllName = 'Roslyn.Services.CSharp.dll'
    $dllVersion = '1.2.20906.1'
    $install = $true
    if (Test-Path $dllGacPath)
    {
    	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
    	{
    		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
    		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
    		{
    			$install = $false
    		}
    	}
    }
    if ($install -eq $true)
    {
        $installRoslynPackage = $true
    }
}
if ($installRoslynPackage -eq $false)
{
    $dllGacPath = Join-Path $gacPath 'Roslyn.Utilities'
    $dllName = 'Roslyn.Utilities.dll'
    $dllVersion = '1.2.20906.1'
    $install = $true
    if (Test-Path $dllGacPath)
    {
    	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
    	{
    		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
    		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
    		{
    			$install = $false
    		}
    	}
    }
    if ($install -eq $true)
    {
        $installRoslynPackage = $true
    }
}
if ($installRoslynPackage -eq $true)
{
    Install-Package Roslyn -Version 1.2.20906.2
    cd $gacUtilFolder
    $packagesPath = Join-Path $toolsPath "..\.."
    foreach ($roslynPackagePath in [System.IO.Directory]::GetDirectories($packagesPath)|?{[System.IO.Path]::GetFileName($_).StartsWith("Roslyn.")})
    {
    	$roslynPackageLibPath = Join-Path $roslynPackagePath "lib\net45"
    	if (Test-Path $roslynPackageLibPath)
    	{
    		foreach ($roslynDll in [System.IO.Directory]::GetFiles($roslynPackageLibPath) | ?{$_.EndsWith(".dll")})
    		{
    			$dllVersion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($roslynDll).FileVersion
    			$dllGacPath = Join-Path $gacPath ([System.IO.Path]::GetFileNameWithoutExtension($roslynDll))
    			$install = $true
    			if (Test-Path $dllGacPath)
    			{
    				foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
    				{
    					$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($roslynDll))
    					if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
    					{
    						$install = $false
    					}
    				}
    			}
    			if ($install)
    			{
    				Write-Host ("Deploy " + ([System.IO.Path]::GetFileNameWithoutExtension($roslynDll) + " in GAC"))
    				.\gacutil.exe -i $roslynDll
    				$install = $true
    				if (Test-Path $dllGacPath)
    				{
    					foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
    					{
    						$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($roslynDll))
    						if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
    						{
    							$install = $false
    						}
    					}
    				}
    				if ($install -eq $true)
    				{
    					Uninstall-Package Roslyn -RemoveDependencies
    					throw "For the first installation, you must run as administrator"
    				}
    			}
    		}
    	}
    }
    
    Uninstall-Package Roslyn -RemoveDependencies
}

if ($DTE.Version -eq '12.0')
{
    $dllGacPath = Join-Path $gacPath 'System.Collections.Immutable'
    $dllName = 'System.Collections.Immutable.dll'
    $dllVersion = '1.1.20.0'
    $install = $true
    if (Test-Path $dllGacPath)
    {
    	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
    	{
    		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
    		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
    		{
    			$install = $false
    		}
    	}
    }
    if ($install -eq $true)
    {
        $installRoslynPackage = $true
    }
    if ($installRoslynPackage -eq $false)
    {
        $dllGacPath = Join-Path $gacPath 'System.Reflection.Metadata'
        $dllName = 'System.Reflection.Metadata.dll'
        $dllVersion = '1.0.11.0'
        $install = $true
        if (Test-Path $dllGacPath)
        {
        	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
        	{
        		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
        		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
        		{
        			$install = $false
        		}
        	}
        }
        if ($install -eq $true)
        {
            $installRoslynPackage = $true
        }
    }
    if ($installRoslynPackage -eq $false)
    {
        $dllGacPath = Join-Path $gacPath 'Microsoft.CodeAnalysis'
        $dllName = 'Microsoft.CodeAnalysis.dll'
        $dllVersion = '0.7.40523.1'
        $install = $true
        if (Test-Path $dllGacPath)
        {
        	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
        	{
        		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
        		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
        		{
        			$install = $false
        		}
        	}
        }
        if ($install -eq $true)
        {
            $installRoslynPackage = $true
        }
    }
    if ($installRoslynPackage -eq $false)
    {
        $dllGacPath = Join-Path $gacPath 'Microsoft.CodeAnalysis.CSharp'
        $dllName = 'Microsoft.CodeAnalysis.CSharp.dll'
        $dllVersion = '0.7.40523.1'
        $install = $true
        if (Test-Path $dllGacPath)
        {
        	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
        	{
        		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
        		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
        		{
        			$install = $false
        		}
        	}
        }
        if ($install -eq $true)
        {
            $installRoslynPackage = $true
        }
    }
    if ($installRoslynPackage -eq $false)
    {
        $dllGacPath = Join-Path $gacPath 'Microsoft.CodeAnalysis.CSharp.Workspaces'
        $dllName = 'Microsoft.CodeAnalysis.CSharp.Workspaces.dll'
        $dllVersion = '0.7.40523.1'
        $install = $true
        if (Test-Path $dllGacPath)
        {
        	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
        	{
        		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
        		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
        		{
        			$install = $false
        		}
        	}
        }
        if ($install -eq $true)
        {
            $installRoslynPackage = $true
        }
    }
    if ($installRoslynPackage -eq $false)
    {
        $dllGacPath = Join-Path $gacPath 'Microsoft.CodeAnalysis.Workspaces'
        $dllName = 'Microsoft.CodeAnalysis.Workspaces.dll'
        $dllVersion = '0.7.40523.1'
        $install = $true
        if (Test-Path $dllGacPath)
        {
        	foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
        	{
        		$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($dllName))
        		if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
        		{
        			$install = $false
        		}
        	}
        }
        if ($install -eq $true)
        {
            $installRoslynPackage = $true
        }
    }
    if ($installRoslynPackage -eq $true)
    {
        Install-Package Microsoft.CodeAnalysis -Pre -Version 0.7.4052301-beta
        cd $gacUtilFolder
        $packagesPath = Join-Path $toolsPath "..\.."
        foreach ($roslynPackagePath in [System.IO.Directory]::GetDirectories($packagesPath)|?{[System.IO.Path]::GetFileName($_).StartsWith("Microsoft.CodeAnalysis.") -or [System.IO.Path]::GetFileName($_).StartsWith("Microsoft.Bcl.")})
        {
        	$roslynPackageLibPath = Join-Path $roslynPackagePath "lib\net45"
        	if (-not (Test-Path $roslynPackageLibPath))
        	{
        	   $roslynPackageLibPath = Join-Path $roslynPackagePath "lib\portable-net45+win8"
        	}
        	if (Test-Path $roslynPackageLibPath)
        	{
        		foreach ($roslynDll in [System.IO.Directory]::GetFiles($roslynPackageLibPath) | ?{$_.EndsWith(".dll")})
        		{
        			$dllVersion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($roslynDll).FileVersion
        			$dllGacPath = Join-Path $gacPath ([System.IO.Path]::GetFileNameWithoutExtension($roslynDll))
        			$install = $true
        			if (Test-Path $dllGacPath)
        			{
        				foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
        				{
        					$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($roslynDll))
        					if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
        					{
        						$install = $false
        					}
        				}
        			}
        			if ($install)
        			{
        				Write-Host ("Deploy " + ([System.IO.Path]::GetFileNameWithoutExtension($roslynDll) + " in GAC"))
        				.\gacutil.exe -i $roslynDll
        				$install = $true
        				if (Test-Path $dllGacPath)
        				{
        					foreach ($gacFolder in [System.IO.Directory]::GetDirectories($dllGacPath))
        					{
        						$dllGacPathLoop = Join-Path $gacFolder ([System.IO.Path]::GetFileName($roslynDll))
        						if ((Test-Path $dllGacPathLoop) -and ($dllVersion -eq [System.Diagnostics.FileVersionInfo]::GetVersionInfo($dllGacPathLoop).FileVersion))
        						{
        							$install = $false
        						}
        					}
        				}
        				if ($install -eq $true)
        				{
        					Uninstall-Package Microsoft.CodeAnalysis -RemoveDependencies
        					throw "For the first installation, you must run as administrator"
        				}
        			}
        		}
        	}
        }
        
        Uninstall-Package Microsoft.CodeAnalysis -RemoveDependencies
    }
}