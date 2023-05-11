from reportlab.lib.pagesizes import letter
from reportlab.lib import colors
from reportlab.lib.units import inch
from reportlab.pdfgen import canvas
from reportlab.lib.utils import ImageReader
from datetime import datetime
import qrcode
import sys 

id = sys.argv[1]
# id = "18"
data = datetime.now().strftime("%d/%m/%Y")
hora = datetime.now().strftime("%H:%M:%S")

canva = canvas.Canvas("ticket.pdf", pagesize=(260, 530))

canva.drawString(10, 500, "DATA: " + str(data))

canva.drawString(10, 480, "HORA: " + str(hora))

canva.line(10, 460, 250, 460)

canva.drawString(10, 440, "ID: " + id)

canva.drawString(10, 420, "ESTACIONAMENTO X")

qr = qrcode.make(str(id))
qr.save("code.png")

canva.drawImage("code.png", 10, 300, width=100, height=100)

canva.showPage()
canva.save()
