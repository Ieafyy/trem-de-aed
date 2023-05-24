from reportlab.lib.pagesizes import letter
from reportlab.lib import colors
from reportlab.lib.units import inch
from reportlab.pdfgen import canvas
from reportlab.lib.utils import ImageReader
from datetime import datetime
import qrcode
import sys
import os

id = sys.argv[1]
# id = "19"

diretorio_atual = os.path.dirname(os.path.abspath(__file__))

pdf = f'ticket({id}).pdf'
code = f'code({id}).png'

path1 = os.path.join(diretorio_atual, '..', 'Dados', 'Tickets', pdf)
path2 = os.path.join(diretorio_atual, '..', 'Dados', 'Tickets', code)

data = datetime.now().strftime("%d/%m/%Y")
hora = datetime.now().strftime("%H:%M:%S")

canva = canvas.Canvas(path1, pagesize=(260, 530))

canva.drawString(10, 500, "DATA: " + str(data))

canva.drawString(10, 480, "HORA: " + str(hora))

canva.line(10, 460, 250, 460)

canva.drawString(10, 440, "ID: " + id)

canva.drawString(10, 420, "ESTACIONAMENTO X")

qr = qrcode.make(str(id))
qr.save(path2)

canva.drawImage(path2, 10, 300, width=100, height=100)

canva.showPage()
canva.save()