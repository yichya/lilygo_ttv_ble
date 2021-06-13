import time


def init_network():
    import network
    try:
        sta_if = network.WLAN(network.STA_IF)
        if not sta_if.isconnected():
            sta_if.active(True)
            sta_if.connect("CU_ZFeb", "bat7bde9")
        return sta_if.ifconfig()[0]
    except:
        return "0.0.0.0"


def init_touch():
    from machine import Pin

    # Touch Power
    Pin(32, Pin.PULL_UP).on()
    
    # Touch Pin
    return Pin(15, Pin.IN)


def init_oled_power():
    from machine import Pin
    oled_power = Pin(33, Pin.PULL_UP)
    oled_power.on()
    return oled_power


def init_display():
    from machine import Pin, SoftSPI
    import ssd1306
    spi = SoftSPI(baudrate=100000, polarity=1, phase=0, sck=Pin(18), mosi=Pin(23), miso=Pin(32))
    return ssd1306.SSD1306_SPI(128,64,spi,Pin(19),Pin(4),Pin(5))


def on_rx(uart):
    def d():
        c = uart.read().decode().strip()
        for f in c.split("\n"):
            command = f.strip()
            print(command)
            eval(command)
    return d


def init_ble():
    import bluetooth
    from ble_uart_peripheral import BLEUART

    ble = bluetooth.BLE()
    uart = BLEUART(ble, "LilyGo TTV", 2048)
    uart.irq(handler=on_rx(uart))
    mac = 0
    for i, x in enumerate(ble.config('mac')[1]):
        mac += x << (8 * (5 - i))
    return mac


def draw_pbm_icon(name, x, y):
    import framebuf
    with open(name, 'rb') as f:
        f.readline() # Magic number
        f.readline() # Dimensions
        data = bytearray(f.read())
    fbuf = framebuf.FrameBuffer(data, 128, 64, framebuf.MONO_HLSB)
    display.blit(fbuf, x, y)


def draw_big_hex_number(n, x, y):
    for v in str(n):
        # top
        if v in ["2", "3", "5", "6", "7", "8", "9", "0", "a", "c", "e", "f"]:
            display.fill_rect(x + 3, y, 6, 3, 1)
            display.line(x + 2, y + 1, x + 9, y + 1, 1)

        # center
        if v in ["2", "3", "4", "5", "6", "8", "9", "a", "b", "d", "e", "f"]:
            display.fill_rect(x + 3, y + 9, 6, 3, 1)
            display.line(x + 2, y + 10, x + 9, y + 10, 1)

        # bottom
        if v in ["2", "3", "5", "6", "8", "9", "0", "b", "c", "d", "e"]:
            display.fill_rect(x + 3, y + 18, 6, 3, 1)
            display.line(x + 2, y + 19, x + 9, y + 19, 1)

        # left top
        if v in ["4", "5", "6", "8", "9", "0", "a", "b", "c", "e", "f"]:
            display.fill_rect(x, y + 3, 3, 6, 1)
            display.line(x + 1, y + 2, x + 1, y + 9, 1)

        # left bottom
        if v in ["2", "6", "8", "0", "a", "b", "c", "d", "e", "f"]:
            display.fill_rect(x, y + 12, 3, 6, 1)
            display.line(x + 1, y + 11, x + 1, y + 18, 1)

        # right top
        if v in ["1", "2", "3", "4", "7", "8", "9", "0", "a", "d"]:
            display.fill_rect(x + 9, y + 3, 3, 6, 1)
            display.line(x + 10, y + 2, x + 10, y + 9, 1)

        # right bottom
        if v in ["1", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "d"]:
            display.fill_rect(x + 9, y + 12, 3, 6, 1)
            display.line(x + 10, y + 11, x + 10, y + 18, 1)
        
        x += 16


ipaddr = init_network()
touch = init_touch()
display = init_display()
oled_power = init_oled_power()
addr = init_ble()

display.text("Connect using", 0, 0, 1)
display.text("this address:", 0, 12, 1)
display.text(str(addr), 0, 34, 1)
display.text(ipaddr, 0, 56, 1)
display.show()
