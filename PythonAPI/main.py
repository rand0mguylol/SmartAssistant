from core.core import *

if __name__ == '__main__':
  nyx_agent = Agent(cf, verbose=2)
  nyx_agent.run()


  # test local mic
  # print(nyx_agent.Mic.active_listen())

  # test local speaker
  # nyx_agent.Mic.say("It's fine!")
  # time.sleep(2)
