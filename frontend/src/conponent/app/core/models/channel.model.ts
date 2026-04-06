export interface ChannelModel {
  id: string;
  name: string;
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
}
