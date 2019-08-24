// vim:tabstop=2:shiftwidth=2:expandtab:cinoptions=(s,U1,m1
// Copyright (C) 2001 Rik Hemsley (rikkus) <rik@kde.org>

#ifndef BACKWARD_CLOCK_H
#define BACKWARD_CLOCK_H

#include <qwidget.h>

class QTimer;

class BackwardClock : public QWidget
{
  Q_OBJECT

  public:

    BackwardClock(QWidget * parent = 0, const char * name = 0);
    virtual ~BackwardClock();

  protected:

    virtual void paintEvent(QPaintEvent *);
    virtual void resizeEvent(QResizeEvent *);

    virtual void drawFace(QPainter &, QTime);

  protected slots:

    virtual void slotDraw();

  private:

    QTimer * timer_;
};

#endif
