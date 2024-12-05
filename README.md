"# beeTech-Solutions" 

This is an API for the website created to showcase the technology accessories offered at the store. This is an overview of my back-end API development and SQL abilities.

Developed the database using SQL with Microsoft SQL Server Management Studio. The database is hosted on Azure.

Developed the API using C# and Entity Framework Core.



import PyPDF2
import re
from openpyxl import Workbook

# Function to extract text from encrypted PDF
def extract_text_from_pdf(pdf_file_path, password):
    with open(pdf_file_path, 'rb') as file:
        reader = PyPDF2.PdfReader(file)
        
        # Decrypt the PDF using the password
        if reader.is_encrypted:
            reader.decrypt(password)  # Unlock the PDF with the password
            
        text = ""
        for page_num in range(len(reader.pages)):
            page = reader.pages[page_num]
            text += page.extract_text()
    return text

# Function to extract a specific field using regex
def extract_field(text, field_name):
    # Example: Search for a field based on a label (adjust regex as needed)
    pattern = rf"{field_name}[:\s]+([^\n]+)"
    match = re.search(pattern, text)
    if match:
        return match.group(1).strip()  # Return the first captured group
    return None

# Provide the PDF file path and password
pdf_file_path = "CML1239.pdf"
password = "1239"  

# Extract text from the PDF
pdf_text = extract_text_from_pdf(pdf_file_path, password)

# field to check for
field_name = "Total Due"  # Example: "Invoice Number", "Name", etc.
extracted_field = extract_field(pdf_text, field_name)

# Create a new Excel file and write the extracted field
if extracted_field:
    wb = Workbook()
    ws = wb.active
    #ws['A1'] = field_name  # Write the field name in cell A1
    ws['A2'] = extracted_field  # Write the extracted field value in cell A2

    # Save to an Excel file
    excel_file_path = "output.xlsx"
    wb.save(excel_file_path)
    print(f"Field extracted and saved to {excel_file_path}")
else:
    print(f"Field '{field_name}' not found in the PDF.")
