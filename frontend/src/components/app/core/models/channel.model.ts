import {EChannel} from '../../shared/enum/EChannel';

export interface ChannelModel {
  id: string;
  name: string;
  type: EChannel;
}

export interface GetChannelsResponse{
  channels: ChannelModel[];
}

export interface GetChannelsRequest{
  serverId: string;
}

export interface AddChannelRequest{
  serverId: string;
  name: string;
  type: EChannel;
}
