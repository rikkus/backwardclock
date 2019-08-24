#include "BackwardClock.h"

#include <qapplication.h>

int main(int argc, char ** argv)
{
  QApplication app(argc, argv);

  BackwardClock * bc = new BackwardClock;

  bc->show();

  app.setMainWidget(bc);

  return app.exec();
}
