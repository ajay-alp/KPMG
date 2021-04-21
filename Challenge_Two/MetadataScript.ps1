[CmdletBinding()]
Param (
	[Parameter(Mandatory=$false)] [String]$inputCategory=""	
)

if ($inputCategory -eq "") { 
	$categoryObject = Get-EC2InstanceMetadata -ListCategory | ConvertTo-Json | ConvertFrom-Json
    $finalJson = @()
    foreach ($category in $categoryObject) {
        $categoryKey = "" | Select-Object $category
        $categoryKey.$category = Get-EC2InstanceMetadata -Category $category
        $finalJson += $categoryKey
    }
    $finalJson | ConvertTo-Json
} 
else {  
	$categoryKey = "" | Select-Object $inputCategory
    $categoryKey.$inputCategory = Get-EC2InstanceMetadata -Category $inputCategory
    $categoryKey | ConvertTo-Json
}