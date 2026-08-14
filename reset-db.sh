#!/bin/bash

set -e

echo "Removing database..."
rm -f secureclicker.db

echo "Removing migrations..."
rm -rf Migrations

echo "Creating fresh migration..."
dotnet ef migrations add InitialCreate

echo "Updating database..."
dotnet ef database update

echo "Database reset complete."