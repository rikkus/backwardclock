/*
  Copyright (C) 2001 Rik Hemsley (rikkus) <rik@kde.org>

  Face drawing routine (C) 1996-2001 the kicker authors. kicker is part
  of the KDE project. See http://www.kde.org

  Permission is hereby granted, free of charge, to any person obtaining a copy
  of this software and associated documentation files (the "Software"), to deal
  in the Software without restriction, including without limitation the rights
  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the Software is
  furnished to do so, subject to the following conditions:

  The above copyright notice and this permission notice shall be included in
  all copies or substantial portions of the Software.

  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
  AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN
  AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
  CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#include "BackwardClock.h"

#include <qtimer.h>
#include <qdatetime.h>
#include <qpainter.h>
#include <qpixmap.h>

BackwardClock::BackwardClock
(
  QWidget * parent,
  const char *name
)
  : QWidget(parent, name, WStyle_Customize | WStyle_Tool)
{
  timer_ = new QTimer(this);
  connect(timer_, SIGNAL(timeout()), SLOT(slotDraw()));
  resize(76, 76);
}

BackwardClock::~BackwardClock()
{
}

  void
BackwardClock::paintEvent(QPaintEvent *)
{
}

  void
BackwardClock::resizeEvent(QResizeEvent *)
{
  slotDraw();
}

  void
BackwardClock::slotDraw()
{
  QPixmap px(size());

  QPainter p(&px);

  p.fillRect(rect(), colorGroup().background());

  QTime t(QTime::currentTime());

  drawFace(p, t);

  setBackgroundPixmap(px);

  QTime currentTime(QTime::currentTime());
  QTime targetTime(currentTime.addSecs(60 - currentTime.second()));

  timer_->start(currentTime.msecsTo(targetTime), true);

  QDate d(QDate::currentDate());

  setCaption
  (
    QString("%1 %2/%3")
    .arg(QDate::shortDayName(d.dayOfWeek()))
    .arg(d.day())
    .arg(QDate::shortMonthName(d.month()))
  );
}

  void
BackwardClock::drawFace(QPainter & p, QTime t)
{
  // Adapted from kicker, (C) 1996-2001 the kicker authors. See module kdebase
  // of the KDE project.

  const int border = 10;
  const int hourHandBaseWidth   = 30;
  const int hourHandLength      = 250;
  const int minuteHandBaseWidth = 10;
  const int minuteHandLength    = 400;
  const int hourMarkStart       = 460;
  const int hourMarkEnd         = 500;

  p.setPen    (colorGroup().foreground());
  p.setBrush  (colorGroup().foreground());

  QPoint centre = rect().center();

  int diameter = QMIN(width(), height()) - border;

  QWMatrix matrix;

  matrix.translate(centre.x(), centre.y());
  matrix.scale(diameter / 1000.0, diameter / 1000.0);

  // Hour hand.

  double hourAngle = 30 * (t.hour() % 12 - 3) + t.minute() / 2;

  matrix.rotate(-hourAngle + 180);
  {
    p.setWorldMatrix(matrix);

    QPointArray a;

    a.setPoints
      (
        4,
        -hourHandBaseWidth, 0,
        0, -hourHandBaseWidth,
        hourHandLength, 0,
        0, hourHandBaseWidth
      );

    p.drawPolygon(a);
  }
  matrix.rotate(hourAngle + 180);

  // Minute hand.

  double minuteAngle = 6 * (t.minute() - 15);

  matrix.rotate(-minuteAngle + 180);
  {
    p.setWorldMatrix(matrix);

    QPointArray a;

    a.setPoints
      (
        4,
        -minuteHandBaseWidth, 0,
        0, -minuteHandBaseWidth,
        minuteHandLength, 0,
        0, minuteHandBaseWidth
      );

    p.drawPolygon(a);
  }
  matrix.rotate(minuteAngle + 180);

  // Hour marks

  for (int i = 0; i < 12; i++)
  {
    p.setWorldMatrix(matrix);
    p.drawLine(hourMarkStart, 0, hourMarkEnd, 0);
    matrix.rotate(30);
  }
}

// vim:tabstop=2:shiftwidth=2:expandtab:cinoptions=(s,U1,m1
