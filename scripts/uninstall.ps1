$service = Get-Service -Name TopShelf.Demo -ErrorAction SilentlyContinue

if ($service.Length -gt 0 -and $service.Status -eq 'Running') {
    
	# If wedon't stop the service, the build process will fail
	# because files are locked

    echo "Stopping service"
	Stop-Service -Name TopShelf.Demo -ErrorAction SilentlyContinue

    }