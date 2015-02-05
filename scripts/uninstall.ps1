$name = "TopShelf Demo"
$service = Get-Service -Name $name -ErrorAction SilentlyContinue

if ($service.Length -gt 0 -and $service.Status -eq 'Running') {
    
	# If we don't stop the service, the build process will fail
	# because files are locked

    echo "Stopping service" $name
	Stop-Service -Name $name -ErrorAction SilentlyContinue

    }